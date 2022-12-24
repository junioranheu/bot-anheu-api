using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            //
        }

        // Outros;
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        // Usuários e afins;
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioTipo> UsuariosTipos { get; set; }

        // Mensagens, respostas e afins;
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<EmocaoTipo> EmocoesTipos { get; set; }
        public DbSet<MensagemEmocao> MensagensEmocoes { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<RespostaEmocao> RespostasEmocoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
