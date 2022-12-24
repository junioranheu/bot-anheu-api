using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Biblioteca.Utils;

namespace API.Models
{
    public class Mensagem
    {
        [Key]
        public int MensagemId { get; set; }
        public string? Texto { get; set; } = null;

        // Fk (De lá pra cá);
        public int? UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario? Usuarios { get; set; }

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;
    }
}
