using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja_e_commerce.Models.Clientes
{
    public class Telefone
    {
        [Key]
        public int Cod_Telefone { get; set; }

        [ForeignKey("Cod_cliente")]
        public Cliente cliente { get; set; }

        public string str_Telefone { get; set; } = null;
    }
}
