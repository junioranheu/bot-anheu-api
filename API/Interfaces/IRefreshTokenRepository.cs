using API.DTOs;

namespace API.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task? Adicionar(RefreshTokenDTO dto);
        Task<string>? GetRefreshTokenByUsuarioId(int usuarioId);
    }
}
