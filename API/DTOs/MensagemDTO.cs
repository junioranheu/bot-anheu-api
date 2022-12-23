using System.ComponentModel.DataAnnotations;
using static Biblioteca.Utils;

namespace API.DTOs
{
    public class MensagemDTO : _RetornoApiDTO
    {
        [Key]
        public int MensagemId { get; set; }

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
    }
}
