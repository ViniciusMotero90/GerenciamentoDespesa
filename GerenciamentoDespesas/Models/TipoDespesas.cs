using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDespesas.Models
{
    public class TipoDespesas
    {
        public int TipoDespesasId { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(50, ErrorMessage ="Use menos caracteres.")]
        public string Nome { get; set; }
        public ICollection<Despesas> Despesas { get; set; }
    }
}