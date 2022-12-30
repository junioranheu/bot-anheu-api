using API.Data;
using API.DTOs;
using API.Enums;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static Biblioteca.Utils;

namespace API.Repositories
{
    public class MensagemRepository : IMensagemRepository
    {
        public readonly Context _context;
        private readonly IMapper _map;

        public MensagemRepository(Context context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        public async Task? Adicionar(MensagemDTO dto)
        {
            Mensagem mensagem = _map.Map<Mensagem>(dto);

            await _context.AddAsync(mensagem);
            await _context.SaveChangesAsync();
        }

        public async Task? Atualizar(MensagemDTO dto)
        {
            Mensagem mensagem = _map.Map<Mensagem>(dto);

            _context.Update(mensagem);
            await _context.SaveChangesAsync();
        }

        public async Task? Deletar(int id)
        {
            var dados = await _context.Mensagens.FindAsync(id);

            if (dados == null)
            {
                throw new Exception("Registro com o id " + id + " não foi encontrado");
            }

            _context.Mensagens.Remove(dados);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MensagemDTO>>? GetTodos()
        {
            var todos = await _context.Mensagens.
                        Include(u => u.Usuarios).
                        Where(i => i.IsAtivo == true).AsNoTracking().ToListAsync();

            List<MensagemDTO> dto = _map.Map<List<MensagemDTO>>(todos);
            return dto;
        }

        public async Task<MensagemDTO>? GetById(int id)
        {
            var byId = await _context.Mensagens.
                       Where(m => m.MensagemId == id && m.IsAtivo == true).AsNoTracking().FirstOrDefaultAsync();

            MensagemDTO dto = _map.Map<MensagemDTO>(byId);
            return dto;
        }

        public async Task<RespostaDTO>? EnviarMensagem(MensagemDTO dto)
        {
            var rand = new Random();
            RespostaDTO erro = new() { Erro = true, CodigoErro = (int)CodigosErrosEnum.MensagemVazia, MensagemErro = GetDescricaoEnum(CodigosErrosEnum.MensagemVazia) };

            if (String.IsNullOrEmpty(dto?.Texto))
            {
                return erro;
            }

            // #01 - Registrar mensagem;
            dto.Texto = dto?.Texto?.ToLowerInvariant() ?? "";
            Mensagem mensagem = _map.Map<Mensagem>(dto);
            await _context.AddAsync(mensagem);
            await _context.SaveChangesAsync();

            // #02 - Analisar mensagem;
            // #02.01 - Quebrar o texto e inserir em array;
            string[]? palavras = dto?.Texto.Split(' ');

            if (palavras?.Length > 0)
            {
                List<Resposta> listRespostas = new();

                foreach (var item in palavras)
                {
                    var respostas = await _context.Respostas.
                                    Where(r => r.Texto.Contains(RemoverAcentos(item)) && r.IsAtivo == true).AsNoTracking().ToListAsync();

                    listRespostas?.AddRange(respostas);
                }

                if (listRespostas.Count == 0)
                {
                    List<string> listaNaoSei = new()
                    {
                        "Eu não sei como responder essa frase ainda!",
                        "Eu não aprendi a como responder essa frase ainda!",
                        "Não entendi!",
                        "Não aprendi isso ainda!"
                    };

                    RespostaDTO erro2 = new() { Texto = listaNaoSei.ElementAt(rand.Next(listaNaoSei.Count)), Erro = true, CodigoErro = (int)CodigosErrosEnum.PalavraDesconhecida, MensagemErro = GetDescricaoEnum(CodigosErrosEnum.PalavraDesconhecida) };
                    return erro2;
                }

                var respostaAleatoria = listRespostas.ElementAt(rand.Next(listRespostas.Count));
                RespostaDTO resultadoDTO = _map.Map<RespostaDTO>(respostaAleatoria);

                return resultadoDTO;
            }

            return erro;
        }
    }
}
