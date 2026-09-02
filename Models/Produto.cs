using System.ComponentModel.DataAnnotations;

namespace Loja_e_commerce.Models
{
    public class Produto
    {
        [Key]
        public int Cod_Prod { get; set; }
        public string name { get; set; }
        public string descricao { get; set; }
        public float preco { get; set; }
        public int qtd_estoque { get; set; }
    }
}
