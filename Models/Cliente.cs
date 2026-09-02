using System.ComponentModel.DataAnnotations;

namespace Loja_e_commerce.Models
{
    public class Cliente
    {
        [Key]
        public int Cod_cliente { get; set; }
        public string nome { get; set; }
        public string rua { get; set; }
        public int num_casa { get; set; }
        public string bairro { get; set; }
    }
}
