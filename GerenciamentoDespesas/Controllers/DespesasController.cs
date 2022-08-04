using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciamentoDespesas.Date;
using GerenciamentoDespesas.Models;

namespace GerenciamentoDespesas.Controllers
{
    public class DespesasController : Controller
    {
        private readonly Context _context;

        public DespesasController(Context context)
        {
            _context = context;
        }

        // GET: Despesas
        public async Task<IActionResult> Index()
        {
            var context = _context.Despesas.Include(d => d.Meses).Include(d => d.TipoDespesas);
            return View(await context.ToListAsync());
        }

        // GET: Despesas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesas = await _context.Despesas
                .Include(d => d.Meses)
                .Include(d => d.TipoDespesas)
                .FirstOrDefaultAsync(m => m.DespesasId == id);
            if (despesas == null)
            {
                return NotFound();
            }

            return View(despesas);
        }

        // GET: Despesas/Create
        public IActionResult Create()
        {
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "Nome");
            ViewData["TipoDespesasId"] = new SelectList(_context.TipoDespesas, "TipoDespesasId", "Nome");
            return View();
        }

        // POST: Despesas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DespesasId,MesId,TipoDespesasId,Valor")] Despesas despesas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(despesas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "Nome", despesas.MesId);
            ViewData["TipoDespesasId"] = new SelectList(_context.TipoDespesas, "TipoDespesasId", "Nome", despesas.TipoDespesasId);
            return View(despesas);
        }

        // GET: Despesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesas = await _context.Despesas.FindAsync(id);
            if (despesas == null)
            {
                return NotFound();
            }
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "Nome", despesas.MesId);
            ViewData["TipoDespesasId"] = new SelectList(_context.TipoDespesas, "TipoDespesasId", "Nome", despesas.TipoDespesasId);
            return View(despesas);
        }

        // POST: Despesas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DespesasId,MesId,TipoDespesasId,Valor")] Despesas despesas)
        {
            if (id != despesas.DespesasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(despesas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespesasExists(despesas.DespesasId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "Nome", despesas.MesId);
            ViewData["TipoDespesasId"] = new SelectList(_context.TipoDespesas, "TipoDespesasId", "Nome", despesas.TipoDespesasId);
            return View(despesas);
        }

        // GET: Despesas/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesas = await _context.Despesas
                .Include(d => d.Meses)
                .Include(d => d.TipoDespesas)
                .FirstOrDefaultAsync(m => m.DespesasId == id);
            if (despesas == null)
            {
                return NotFound();
            }

            return View(despesas);
        }

        // POST: Despesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var despesas = await _context.Despesas.FindAsync(id);
            _context.Despesas.Remove(despesas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespesasExists(int id)
        {
            return _context.Despesas.Any(e => e.DespesasId == id);
        }
    }
}
