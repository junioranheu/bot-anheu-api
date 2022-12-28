using API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Biblioteca.Utils;

namespace API.DTOs
{
    public class MensagemDTO : _RetornoApiDTO
    {
        [Key]
        public int MensagemId { get; set; }
        public string? Texto { get; set; } = null;

        // Fk (De lá pra cá);
        public int? UsuarioId { get; set; }
        [JsonIgnore]
        public UsuarioDTO? Usuarios { get; set; }

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;

        // Fk (De cá pra lá);
        [JsonIgnore]
        public ICollection<MensagemResposta>? MensagensRespostas { get; set; }
    }
}
