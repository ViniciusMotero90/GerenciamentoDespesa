using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDespesas.Models
{
    public class Meses
    {
        public int MesId { get; set; }
        public string Nome { get; set; }
        public ICollection<Despesas> Despesas { get; set; }
        public int SalarioId { get; set; }
        public Salarios Salarios { get; set; }
    }
}