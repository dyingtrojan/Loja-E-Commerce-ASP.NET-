using System.ComponentModel.DataAnnotations;

namespace Loja_e_commerce.Models
{
    public class Estoque
    {
        [Key]
        public int Cod_Estoque { get; set; }
        public int Cod_Funcionario { get; set; }
        public int Cod_Produto { get; set; }
    }
}
