using System.ComponentModel.DataAnnotations;
using static Biblioteca.Utils;

namespace API.Models
{
    public class RefreshToken
    {
        [Key]
        public int RefreshTokenId { get; set; }
        public string? RefToken { get; set; } = null;

        // Fk (De lá pra cá);
        public int UsuarioId { get; set; }
        public Usuario? Usuarios { get; set; }

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
    }
}
