using System.ComponentModel.DataAnnotations;
using static Biblioteca.Utils;

namespace API.Models
{
    public class MensagemResposta
    {
        [Key]
        public int MensagemRespostaId { get; set; }

        // Fk (De lá pra cá);
        public int MensagemId { get; set; }
        public Mensagem? Mensagens { get; set; }

        // Fk (De lá pra cá);
        public int RespostaId { get; set; }
        public Resposta? Respostas { get; set; }

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;
    }
}
