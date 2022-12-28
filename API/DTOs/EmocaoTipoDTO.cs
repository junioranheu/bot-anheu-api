using API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Biblioteca.Utils;

namespace API.DTOs
{
    public class EmocaoTipoDTO : _RetornoApiDTO
    {
        [Key]
        public int EmocaoTipoId { get; set; }
        public string? Emocao { get; set; } = null;
        public string? Descricao { get; set; } = null;

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;

        // Fk (De cá pra lá);
        [JsonIgnore]
        public ICollection<RespostaEmocaoDTO>? RespostasEmocoes { get; set; }
    }
}
