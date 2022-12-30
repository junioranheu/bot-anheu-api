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
                await context.Mensagens.AddAsync(new Mensagem() { MensagemId = 1, Texto = "olá", UsuarioId = null, DataRegistro = dataAgora, IsAtivo = true });
                await context.Mensagens.AddAsync(new Mensagem() { MensagemId = 2, Texto = "oi", UsuarioId = 2, DataRegistro = dataAgora, IsAtivo = true });
                await context.Mensagens.AddAsync(new Mensagem() { MensagemId = 3, Texto = "tchau", UsuarioId = 2, DataRegistro = dataAgora, IsAtivo = true });
                await context.Mensagens.AddAsync(new Mensagem() { MensagemId = 4, Texto = "aff", UsuarioId = 2, DataRegistro = dataAgora, IsAtivo = true });
            }

            if (!await context.Respostas.AnyAsync())
            {
                await context.Respostas.AddAsync(new Resposta() { RespostaId = 1, Texto = "ola, tudo bem?", DataRegistro = dataAgora, IsAtivo = true });
                await context.Respostas.AddAsync(new Resposta() { RespostaId = 2, Texto = "ola, tudo certo?", DataRegistro = dataAgora, IsAtivo = true });
                await context.Respostas.AddAsync(new Resposta() { RespostaId = 3, Texto = "ola!", DataRegistro = dataAgora, IsAtivo = true });
                await context.Respostas.AddAsync(new Resposta() { RespostaId = 4, Texto = "oi, tudo de boa?", DataRegistro = dataAgora, IsAtivo = true });
                await context.Respostas.AddAsync(new Resposta() { RespostaId = 5, Texto = "e ai!", DataRegistro = dataAgora, IsAtivo = true });
                await context.Respostas.AddAsync(new Resposta() { RespostaId = 6, Texto = "tchau!", DataRegistro = dataAgora, IsAtivo = true });
                await context.Respostas.AddAsync(new Resposta() { RespostaId = 7, Texto = "ate mais", DataRegistro = dataAgora, IsAtivo = true });
                await context.Respostas.AddAsync(new Resposta() { RespostaId = 8, Texto = "ah, que pena! tchau! :(", DataRegistro = dataAgora, IsAtivo = true });
                await context.Respostas.AddAsync(new Resposta() { RespostaId = 9, Texto = "que foi?", DataRegistro = dataAgora, IsAtivo = true });
                await context.Respostas.AddAsync(new Resposta() { RespostaId = 10, Texto = "aff o que?", DataRegistro = dataAgora, IsAtivo = true });
            }

            if (!await context.RespostasEmocoes.AnyAsync())
            {
                await context.RespostasEmocoes.AddAsync(new RespostaEmocao() { RespostaEmocaoId = 1, RespostaId = 1, EmocaoTipoId = (int)EmocaoTipoEnum.Neutro, DataRegistro = dataAgora, IsAtivo = true });
                await context.RespostasEmocoes.AddAsync(new RespostaEmocao() { RespostaEmocaoId = 2, RespostaId = 2, EmocaoTipoId = (int)EmocaoTipoEnum.Neutro, DataRegistro = dataAgora, IsAtivo = true });
                await context.RespostasEmocoes.AddAsync(new RespostaEmocao() { RespostaEmocaoId = 3, RespostaId = 3, EmocaoTipoId = (int)EmocaoTipoEnum.Neutro, DataRegistro = dataAgora, IsAtivo = true });
                await context.RespostasEmocoes.AddAsync(new RespostaEmocao() { RespostaEmocaoId = 4, RespostaId = 4, EmocaoTipoId = (int)EmocaoTipoEnum.Neutro, DataRegistro = dataAgora, IsAtivo = true });
                await context.RespostasEmocoes.AddAsync(new RespostaEmocao() { RespostaEmocaoId = 5, RespostaId = 5, EmocaoTipoId = (int)EmocaoTipoEnum.Neutro, DataRegistro = dataAgora, IsAtivo = true });
                await context.RespostasEmocoes.AddAsync(new RespostaEmocao() { RespostaEmocaoId = 6, RespostaId = 6, EmocaoTipoId = (int)EmocaoTipoEnum.Neutro, DataRegistro = dataAgora, IsAtivo = true });
                await context.RespostasEmocoes.AddAsync(new RespostaEmocao() { RespostaEmocaoId = 7, RespostaId = 7, EmocaoTipoId = (int)EmocaoTipoEnum.Neutro, DataRegistro = dataAgora, IsAtivo = true });
                await context.RespostasEmocoes.AddAsync(new RespostaEmocao() { RespostaEmocaoId = 8, RespostaId = 8, EmocaoTipoId = (int)EmocaoTipoEnum.Tristeza, DataRegistro = dataAgora, IsAtivo = true });
                await context.RespostasEmocoes.AddAsync(new RespostaEmocao() { RespostaEmocaoId = 9, RespostaId = 9, EmocaoTipoId = (int)EmocaoTipoEnum.Surpresa, DataRegistro = dataAgora, IsAtivo = true });
                await context.RespostasEmocoes.AddAsync(new RespostaEmocao() { RespostaEmocaoId = 10, RespostaId = 10, EmocaoTipoId = (int)EmocaoTipoEnum.Raiva, DataRegistro = dataAgora, IsAtivo = true });
            }

            if (!await context.MensagensRespostas.AnyAsync())
            {
                // Olá;
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 1, MensagemId = 1, RespostaId = 1, DataRegistro = dataAgora, IsAtivo = true });
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 2, MensagemId = 1, RespostaId = 2, DataRegistro = dataAgora, IsAtivo = true });
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 3, MensagemId = 1, RespostaId = 3, DataRegistro = dataAgora, IsAtivo = true });
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 4, MensagemId = 1, RespostaId = 4, DataRegistro = dataAgora, IsAtivo = true });
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 5, MensagemId = 1, RespostaId = 5, DataRegistro = dataAgora, IsAtivo = true });

                // Oi;
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 6, MensagemId = 2, RespostaId = 1, DataRegistro = dataAgora, IsAtivo = true });
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 7, MensagemId = 2, RespostaId = 2, DataRegistro = dataAgora, IsAtivo = true });
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 8, MensagemId = 2, RespostaId = 3, DataRegistro = dataAgora, IsAtivo = true });
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 9, MensagemId = 2, RespostaId = 4, DataRegistro = dataAgora, IsAtivo = true });
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 10, MensagemId = 2, RespostaId = 5, DataRegistro = dataAgora, IsAtivo = true });

                // Tchau;
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 11, MensagemId = 3, RespostaId = 6, DataRegistro = dataAgora, IsAtivo = true });
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 12, MensagemId = 3, RespostaId = 7, DataRegistro = dataAgora, IsAtivo = true });
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 13, MensagemId = 3, RespostaId = 8, DataRegistro = dataAgora, IsAtivo = true });

                // Aff;
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 14, MensagemId = 4, RespostaId = 9, DataRegistro = dataAgora, IsAtivo = true });
                await context.MensagensRespostas.AddAsync(new MensagemResposta() { MensagemRespostaId = 15, MensagemId = 4, RespostaId = 10, DataRegistro = dataAgora, IsAtivo = true });
            }
            #endregion

            await context.SaveChangesAsync();
        }
    }
}
