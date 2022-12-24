using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Biblioteca.Utils;

namespace API.Models
{
    public class Resposta
    {
        [Key]
        public int RespostaId { get; set; }
        public string? Texto { get; set; } = null;

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;

        // Fk (De cá pra lá);
        [JsonIgnore]
        public ICollection<RespostaEmocao>? RespostasEmocoes { get; set; }
    }
}
