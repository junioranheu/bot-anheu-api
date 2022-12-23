using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticarController : Controller
    {
        private readonly IAutenticarService _autenticarService;

        public AutenticarController(IAutenticarService autenticarService)
        {
            _autenticarService = autenticarService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDTO>> Login(UsuarioSenhaDTO dto)
        {
            var authResultado = await _autenticarService.Login(dto);
            return Ok(authResultado);
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UsuarioDTO>> Registrar(UsuarioSenhaDTO dto)
        {
            var authResultado = await _autenticarService.Registrar(dto);
            return Ok(authResultado);
        }

        [HttpPost("refreshToken")]
        public async Task<ActionResult<UsuarioDTO>> RefreshToken(UsuarioSenhaDTO dto)
        {
            var authResultado = await _autenticarService.RefreshToken(dto.Token, dto.RefreshToken);
            return Ok(authResultado);
        }
    }
}
