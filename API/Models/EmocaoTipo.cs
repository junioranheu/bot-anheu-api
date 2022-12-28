using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Biblioteca.Utils;

namespace API.Models
{
    public class EmocaoTipo
    {
        [Key]
        public int EmocaoTipoId { get; set; }
        public string? Emocao { get; set; } = null;
        public string? Descricao { get; set; } = null;

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;

        // Fk (De cá pra lá);
        [JsonIgnore]
        public ICollection<RespostaEmocao>? RespostasEmocoes { get; set; }
    }
}
