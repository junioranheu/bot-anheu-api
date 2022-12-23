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

        // Outros;
        public DbSet<Mensagem> Mensagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
