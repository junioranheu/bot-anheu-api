using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            // #01 - Registrar mensagem;
            Mensagem mensagem = _map.Map<Mensagem>(dto);
            await _context.AddAsync(mensagem);
            await _context.SaveChangesAsync();

            // #02 - Analisar mensagem;

            // #03 - Gerar resposta;
            RespostaDTO resposta = new();

            return resposta;
        } 
    }
}
