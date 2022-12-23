using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly Context _context;
        private readonly IMapper _map;

        public UsuarioRepository(Context context, IMapper map)
        {
            _map = map;
            _context = context;
        }

        public async Task<UsuarioDTO>? Adicionar(UsuarioSenhaDTO dto)
        {
            Usuario usuario = _map.Map<Usuario>(dto);

            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();

            UsuarioDTO usuarioDTO = _map.Map<UsuarioDTO>(usuario);
            return usuarioDTO;
        }

        public async Task<UsuarioDTO>? Atualizar(UsuarioSenhaDTO dto)
        {
            Usuario usuario = _map.Map<Usuario>(dto);
            UsuarioDTO usuarioDTO = _map.Map<UsuarioDTO>(dto);

            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return usuarioDTO;
        }

        public async Task? Deletar(int id)
        {
            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null)
            {
                throw new Exception("Registro com o id " + id + " não foi encontrado");
            }

            _context.Usuarios.Remove(dados);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UsuarioDTO>>? GetTodos()
        {
            var todos = await _context.Usuarios.
                        Include(ut => ut.UsuariosTipos).
                        OrderBy(ui => ui.UsuarioId).AsNoTracking().ToListAsync();

            List<UsuarioDTO> dto = _map.Map<List<UsuarioDTO>>(todos);
            return dto;
        }

        public async Task<UsuarioDTO>? GetById(int id)
        {
            var byId = await _context.Usuarios.
                       Include(ut => ut.UsuariosTipos).
                       Where(ui => ui.UsuarioId == id).AsNoTracking().FirstOrDefaultAsync();

            UsuarioDTO dto = _map.Map<UsuarioDTO>(byId);
            return dto;
        }

        public async Task<UsuarioSenhaDTO>? GetByEmailOuUsuarioSistema(string? email, string? nomeUsuarioSistema)
        {
            var byEmail = await _context.Usuarios.
                Where(e => e.Email == email).AsNoTracking().FirstOrDefaultAsync();

            if (byEmail is null)
            {
                var byNomeUsuario = await _context.Usuarios.
                                    Where(n => n.NomeUsuarioSistema == nomeUsuarioSistema).AsNoTracking().FirstOrDefaultAsync();

                UsuarioSenhaDTO dto1 = _map.Map<UsuarioSenhaDTO>(byNomeUsuario);
                return dto1;
            }

            UsuarioSenhaDTO dto2 = _map.Map<UsuarioSenhaDTO>(byEmail);
            return dto2;
        }
    }
}
