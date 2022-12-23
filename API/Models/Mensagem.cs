using System.ComponentModel.DataAnnotations;
using static Biblioteca.Utils;

namespace API.Models
{
    public class Mensagem
    {
        [Key]
        public int MensagemId { get; set; }

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
    }
}
