using API.Models;
using System.Text.Json.Serialization;

namespace API.DTOs
{
    public class MensagemDTO
    {
        public string? Texto { get; set; } = null;
        public int? UsuarioId { get; set; }

        // Fk (De cá pra lá);
        [JsonIgnore]
        public ICollection<MensagemResposta>? MensagensRespostas { get; set; }
    }
}
