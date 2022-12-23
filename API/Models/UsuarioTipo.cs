using System.ComponentModel.DataAnnotations;
using static Biblioteca.Utils;

namespace API.Models
{
    public class UsuarioTipo
    {
        [Key]
        public int UsuarioTipoId { get; set; }
        public string? Tipo { get; set; } = null;
        public string? Descricao { get; set; } = null;

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
    }
}
