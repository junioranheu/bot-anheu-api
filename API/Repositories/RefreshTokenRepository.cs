using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        public readonly Context _context;
        private readonly IMapper _map;

        public RefreshTokenRepository(Context context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        public async Task? Adicionar(RefreshTokenDTO dto)
        {
            // #1 - Excluir refresh token, caso exista;
            var dados = await _context.RefreshTokens.Where(u => u.UsuarioId == dto.UsuarioId).AsNoTracking().ToListAsync();

            if (dados is not null)
            {
                _context.RefreshTokens.RemoveRange(dados);
            }

            // #2 - Adicionar novo refresh token;
            RefreshToken item = _map.Map<RefreshToken>(dto);

            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<string>? GetRefreshTokenByUsuarioId(int usuarioId)
        {
            // Verificar o refresh token com base no id do usuário e se o usuário de fato está ativo, para ajudar numa possível "black-list";
            var byId = await _context.RefreshTokens.
                       Include(u => u.Usuarios).
                       Where(r => r.UsuarioId == usuarioId && r.Usuarios.IsAtivo == true).
                       AsNoTracking().FirstOrDefaultAsync();

            string refreshToken = byId?.RefToken ?? "";
            return refreshToken;
        }
    }
}
