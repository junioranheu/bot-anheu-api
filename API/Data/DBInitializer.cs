using API.Enums;
using API.Models;
using Microsoft.EntityFrameworkCore;
using static Biblioteca.Utils;

namespace API.Data
{
    public static class DBInitializer
    {
        public static async Task Initialize(Context context)
        {
            // Exclui o esquema, copia as queries, cria esquema/tabelas, popula o BD;
            if (false)
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();

                await Seed(context, HorarioBrasilia());
            }
        }

        private static async Task Seed(Context context, DateTime dataAgora)
        {
            #region seed_usuarios
            if (!await context.UsuariosTipos.AnyAsync())
            {
                await context.UsuariosTipos.AddAsync(new UsuarioTipo() { UsuarioTipoId = (int)UsuarioTipoEnum.Administrador, Tipo = nameof(UsuarioTipoEnum.Administrador), Descricao = "Administrador do sistema", DataRegistro = dataAgora, IsAtivo = true, });
                await context.UsuariosTipos.AddAsync(new UsuarioTipo() { UsuarioTipoId = (int)UsuarioTipoEnum.Usuario, Tipo = GetDescricaoEnum(UsuarioTipoEnum.Usuario), Descricao = "Usuário comum", DataRegistro = dataAgora, IsAtivo = true, });
            }

            if (!await context.Usuarios.AnyAsync())
            {
                await context.Usuarios.AddAsync(new Usuario() { UsuarioId = 1, NomeCompleto = "Administrador do Bot Anheu", Email = "adm@Hotmail.com", NomeUsuarioSistema = "adm", Senha = Criptografar("123"), DataRegistro = dataAgora, UsuarioTipoId = (int)UsuarioTipoEnum.Administrador, IsAtivo = true });
                await context.Usuarios.AddAsync(new Usuario() { UsuarioId = 2, NomeCompleto = "Junior Souza", Email = "juninholorena@Hotmail.com", NomeUsuarioSistema = "junioranheu", Senha = Criptografar("123"), DataRegistro = dataAgora, UsuarioTipoId = (int)UsuarioTipoEnum.Usuario, IsAtivo = true });
            }
            #endregion

            #region seed_mensagens
            if (!await context.Mensagens.AnyAsync())
            {
                await context.Mensagens.AddAsync(new Mensagem() { MensagemId = 1, Texto = "Olá", UsuarioId = null, DataRegistro = dataAgora, IsAtivo = true, });
                await context.Mensagens.AddAsync(new Mensagem() { MensagemId = 2, Texto = "Oi", UsuarioId = 1, DataRegistro = dataAgora, IsAtivo = true, });
            }
            #endregion

            await context.SaveChangesAsync();
        }
    }
}
