using API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Biblioteca.Utils;

namespace API.DTOs
{
    public class RespostaDTO : _RetornoApiDTO
    {
        [Key]
        public int RespostaId { get; set; }
        public string? Texto { get; set; } = null;

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;

        // Fk (De cá pra lá);
        [JsonIgnore]
        public ICollection<RespostaEmocaoDTO>? RespostasEmocoes { get; set; }

        // Fk (De cá pra lá);
        [JsonIgnore]
        public ICollection<MensagemResposta>? MensagensRespostas { get; set; }
    }
}
