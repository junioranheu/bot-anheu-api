using System.ComponentModel.DataAnnotations;
using static Biblioteca.Utils;

namespace API.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string? NomeCompleto { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? NomeUsuarioSistema { get; set; } = null;
        public string? Senha { get; set; } = null;

        // Fk (De lá pra cá);
        public int UsuarioTipoId { get; set; }
        public UsuarioTipo? UsuariosTipos { get; set; }

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;
    }
}
