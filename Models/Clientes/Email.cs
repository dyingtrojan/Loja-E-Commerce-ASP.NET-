using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja_e_commerce.Models.Clientes
{
    public class Email
    {
        [Key]
        public int Cod_Email { get; set; }

        [ForeignKey("Cod_cliente")]
        public Cliente cliente { get; set; }

        public string str_Email { get; set; } = null;
    }
}
