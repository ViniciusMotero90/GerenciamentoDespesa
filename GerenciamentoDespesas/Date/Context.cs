using GerenciamentoDespesas.Mapper;
using GerenciamentoDespesas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDespesas.Date
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {}
        public DbSet<Despesas> Despesas { get; set; }
        public DbSet<TipoDespesas> TipoDespesas { get; set; }
        public DbSet<Salarios> Salarios { get; set; }
        public DbSet<Meses> Meses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoDespesasMapper());
            modelBuilder.ApplyConfiguration(new DespesasMapper());
            modelBuilder.ApplyConfiguration(new SalarioMapper());
            modelBuilder.ApplyConfiguration(new MesesMapper());
        }
    }
}