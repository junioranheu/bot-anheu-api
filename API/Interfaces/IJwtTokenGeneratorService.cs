using API.DTOs;
using System.Security.Claims;

namespace API.Interfaces
{
    public interface IJwtTokenGeneratorService
    {
        string GerarToken(UsuarioSenhaDTO usuario, IEnumerable<Claim>? listaClaims);
        string GerarRefreshToken();
        ClaimsPrincipal? GetInfoTokenExpirado(string? token);
    }
}
