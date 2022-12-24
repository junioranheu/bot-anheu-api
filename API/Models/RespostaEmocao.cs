using System.ComponentModel.DataAnnotations;
using static Biblioteca.Utils;

namespace API.Models
{
    public class RespostaEmocao
    {
        [Key]
        public int RespostaEmocaoId { get; set; }

        // Fk (De lá pra cá);
        public int RespostaId { get; set; }
        public Resposta? Respostas { get; set; }

        // Fk (De lá pra cá);
        public int EmocaoTipoId { get; set; }
        public EmocaoTipo? EmocoesTipos { get; set; }

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;
    }
}
