using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja_e_commerce.Models
{
    public class Compra
    {
        [Key]
        public int Cod_compra { get; set; }
        [ForeignKey("Cod_Prod")]
        public Produto produto { get; set; }
        [NotMapped]
        public DateOnly data_compra { get; set; }
        public float valor_total { get; set; }
    }
}
