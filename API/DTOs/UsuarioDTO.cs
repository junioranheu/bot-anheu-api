using System.ComponentModel.DataAnnotations;
using static Biblioteca.Utils;

namespace API.DTOs
{
    public class UsuarioDTO : _RetornoApiDTO
    {
        [Key]
        public int UsuarioId { get; set; }
        public string? NomeCompleto { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? NomeUsuarioSistema { get; set; } = null;
        public string? Token { get; set; } = null;
        public string? RefreshToken { get; set; } = null;

        // Fk (De lá pra cá);
        public int UsuarioTipoId { get; set; }
        public UsuarioTipoDTO? UsuariosTipos { get; set; }

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;
    }
}
