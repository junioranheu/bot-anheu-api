using System.ComponentModel.DataAnnotations;
using static Biblioteca.Utils;

namespace API.Models
{
    public class MensagemEmocao
    {
        [Key]
        public int MensagemEmocaoId { get; set; }

        // Fk (De lá pra cá);
        public int MensagemId { get; set; }
        public Mensagem? Mensagens { get; set; }

        // Fk (De lá pra cá);
        public int EmocaoTipoId { get; set; }
        public EmocaoTipo? EmocoesTipos { get; set; }

        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public bool IsAtivo { get; set; } = true;
    }
}
