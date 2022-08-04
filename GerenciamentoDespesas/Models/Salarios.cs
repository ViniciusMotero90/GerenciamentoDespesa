using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoDespesas.Models
{
    public class Salarios
    {
        public int SalariosId { get; set; }

        public int MesId { get; set; }
        public Meses Meses { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor inválido.")]
        public double Valor { get; set; }
    }
}