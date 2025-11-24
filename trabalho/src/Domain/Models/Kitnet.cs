
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models
{
    public class Kitnet
    {
        public int Id { get; set; }
        [Required] public string Nome { get; set; }
        [Required] public string Endereco { get; set; }
        [Required] public decimal Preco { get; set; }
    }
}
