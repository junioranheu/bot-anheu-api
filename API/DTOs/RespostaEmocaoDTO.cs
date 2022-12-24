using System.ComponentModel.DataAnnotations;
using static Biblioteca.Utils;

namespace API.DTOs
{
    public class RespostaEmocaoDTO : _RetornoApiDTO
    {
        [Key]
        public int RespostaEmocaoId { get; set; }

        // Fk (De lá pra cá);
        public int RespostaId { get; set; }
        public RespostaDTO? Respostas { get; set; }

        // Fk (De lá pra cá);
        public int EmocaoTipoId { get; set; }
        public EmocaoTipoDTO? EmocoesTipos { get; set; }

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;
    }
}
