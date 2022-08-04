using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoDespesas.Models
{
    public class Despesas
    {
        public int DespesasId { get; set; }
        public int MesId { get; set; }
        public Meses Meses { get; set; }

        public int TipoDespesasId { get; set; }
        public TipoDespesas TipoDespesas { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor inválido.")]
        public double Valor { get; set; }
    }
}