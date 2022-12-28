using System.ComponentModel.DataAnnotations;
using static Biblioteca.Utils;

namespace API.DTOs
{
    public class MensagemRespostaDTO: _RetornoApiDTO
    {
        [Key]
        public int MensagemRespostaId { get; set; }

        // Fk (De lá pra cá);
        public int MensagemId { get; set; }
        public MensagemDTO? Mensagens { get; set; }

        // Fk (De lá pra cá);
        public int RespostaId { get; set; }
        public RespostaDTO? Respostas { get; set; }

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;
    }
}
