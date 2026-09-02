using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja_e_commerce.Models
{
    public class Funcionario
    {
        [Key]
        public int Cod_func {  get; set; }
        public string nome { get; set; }
        public string cargo { get; set; }
        public float salario { get; set; }
        [NotMapped]
        public DateOnly data_nascimento { get; set; }
    }
}
