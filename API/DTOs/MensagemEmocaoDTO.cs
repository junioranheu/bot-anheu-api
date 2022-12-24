using System.ComponentModel.DataAnnotations;
using static Biblioteca.Utils;

namespace API.DTOs
{
    public class MensagemEmocaoDTO : _RetornoApiDTO
    {
        [Key]
        public int MensagemEmocaoId { get; set; }

        // Fk (De lá pra cá);
        public int MensagemId { get; set; }
        public MensagemDTO? Mensagens { get; set; }

        // Fk (De lá pra cá);
        public int EmocaoTipoId { get; set; }
        public EmocaoTipoDTO? EmocoesTipos { get; set; }

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;
    }
}
