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
                await context.UsuariosTipos.AddAsync(new UsuarioTipo() { UsuarioTipoId = (int)UsuarioTipoEnum.Administrador, Tipo = nameof(UsuarioTipoEnum.Administrador), Descricao = "Administrador do sistema", DataRegistro = dataAgora, IsAtivo = true });
                await context.UsuariosTipos.AddAsync(new UsuarioTipo() { UsuarioTipoId = (int)UsuarioTipoEnum.Usuario, Tipo = GetDescricaoEnum(UsuarioTipoEnum.Usuario), Descricao = "Usuário comum", DataRegistro = dataAgora, IsAtivo = true });
            }

            if (!await context.Usuarios.AnyAsync())
            {
                await context.Usuarios.AddAsync(new Usuario() { UsuarioId = 1, NomeCompleto = "Administrador do Bot Anheu", Email = "adm@Hotmail.com", NomeUsuarioSistema = "adm", Senha = Criptografar("123"), DataRegistro = dataAgora, UsuarioTipoId = (int)UsuarioTipoEnum.Administrador, IsAtivo = true });
                await context.Usuarios.AddAsync(new Usuario() { UsuarioId = 2, NomeCompleto = "Junior Souza", Email = "juninholorena@Hotmail.com", NomeUsuarioSistema = "junioranheu", Senha = Criptografar("123"), DataRegistro = dataAgora, UsuarioTipoId = (int)UsuarioTipoEnum.Usuario, IsAtivo = true });
            }
            #endregion

            #region seed_mensagens_respostas_afins
            if (!await context.EmocoesTipos.AnyAsync())
            {
                await context.EmocoesTipos.AddAsync(new EmocaoTipo() { EmocaoTipoId = (int)EmocaoTipoEnum.Alegria, Emocao = EmocaoTipoEnum.Alegria.ToString(), Descricao = GetDescricaoEnum(EmocaoTipoEnum.Alegria), DataRegistro = dataAgora, IsAtivo = true });
                await context.EmocoesTipos.AddAsync(new EmocaoTipo() { EmocaoTipoId = (int)EmocaoTipoEnum.Tristeza, Emocao = EmocaoTipoEnum.Tristeza.ToString(), Descricao = GetDescricaoEnum(EmocaoTipoEnum.Tristeza), DataRegistro = dataAgora, IsAtivo = true });
                await context.EmocoesTipos.AddAsync(new EmocaoTipo() { EmocaoTipoId = (int)EmocaoTipoEnum.Medo, Emocao = EmocaoTipoEnum.Medo.ToString(), Descricao = GetDescricaoEnum(EmocaoTipoEnum.Medo), DataRegistro = dataAgora, IsAtivo = true });
                await context.EmocoesTipos.AddAsync(new EmocaoTipo() { EmocaoTipoId = (int)EmocaoTipoEnum.Nojo, Emocao = EmocaoTipoEnum.Nojo.ToString(), Descricao = GetDescricaoEnum(EmocaoTipoEnum.Nojo), DataRegistro = dataAgora, IsAtivo = true });
                await context.EmocoesTipos.AddAsync(new EmocaoTipo() { EmocaoTipoId = (int)EmocaoTipoEnum.Raiva, Emocao = EmocaoTipoEnum.Raiva.ToString(), Descricao = GetDescricaoEnum(EmocaoTipoEnum.Raiva), DataRegistro = dataAgora, IsAtivo = true });
                await context.EmocoesTipos.AddAsync(new EmocaoTipo() { EmocaoTipoId = (int)EmocaoTipoEnum.Surpresa, Emocao = EmocaoTipoEnum.Surpresa.ToString(), Descricao = GetDescricaoEnum(EmocaoTipoEnum.Surpresa), DataRegistro = dataAgora, IsAtivo = true });
                await context.EmocoesTipos.AddAsync(new EmocaoTipo() { EmocaoTipoId = (int)EmocaoTipoEnum.Neutro, Emocao = EmocaoTipoEnum.Neutro.ToString(), Descricao = GetDescricaoEnum(EmocaoTipoEnum.Neutro), DataRegistro = dataAgora, IsAtivo = true });
                await context.EmocoesTipos.AddAsync(new EmocaoTipo() { EmocaoTipoId = (int)EmocaoTipoEnum.Outro, Emocao = EmocaoTipoEnum.Outro.ToString(), Descricao = GetDescricaoEnum(EmocaoTipoEnum.Outro), DataRegistro = dataAgora, IsAtivo = true });
            }

            if (!await context.Mensagens.AnyAsync())
            {
                await context.Mensagens.AddAsync(new Mensagem() { MensagemId = 1, Texto = "Olá", UsuarioId = null, DataRegistro = dataAgora, IsAtivo = true });
                await context.Mensagens.AddAsync(new Mensagem() { MensagemId = 2, Texto = "Oi", UsuarioId = 2, DataRegistro = dataAgora, IsAtivo = true });
                await context.Mensagens.AddAsync(new Mensagem() { MensagemId = 3, Texto = "Afffff", UsuarioId = 2, DataRegistro = dataAgora, IsAtivo = true });
            }

            if (!await context.MensagensEmocoes.AnyAsync())
            {
                await context.MensagensEmocoes.AddAsync(new MensagemEmocao() { MensagemEmocaoId = 1, MensagemId = 2, EmocaoTipoId = (int)EmocaoTipoEnum.Neutro, DataRegistro = dataAgora, IsAtivo = true });
                await context.MensagensEmocoes.AddAsync(new MensagemEmocao() { MensagemEmocaoId = 2, MensagemId = 3, EmocaoTipoId = (int)EmocaoTipoEnum.Nojo, DataRegistro = dataAgora, IsAtivo = true });
                await context.MensagensEmocoes.AddAsync(new MensagemEmocao() { MensagemEmocaoId = 3, MensagemId = 3, EmocaoTipoId = (int)EmocaoTipoEnum.Raiva, DataRegistro = dataAgora, IsAtivo = true });
            }
            #endregion

            await context.SaveChangesAsync();
        }
    }
}
