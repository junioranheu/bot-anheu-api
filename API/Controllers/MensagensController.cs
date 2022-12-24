using API.DTOs;
using API.Enums;
using API.Filters;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagensController : Controller
    {
        private readonly IMensagemRepository _mensagemRepository;

        public MensagensController(IMensagemRepository mensagemRepository)
        {
            _mensagemRepository = mensagemRepository;
        }

        [HttpPost("adicionar")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<bool>> Adicionar(MensagemDTO dto)
        {
            dto.UsuarioId = Convert.ToInt32(User?.FindFirstValue(ClaimTypes.NameIdentifier)) > 0 ? Convert.ToInt32(User?.FindFirstValue(ClaimTypes.NameIdentifier)) : null;
            await _mensagemRepository.Adicionar(dto);
            return Ok(true);
        }

        [HttpPut("atualizar")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<bool>> Atualizar(MensagemDTO dto)
        {
            await _mensagemRepository.Atualizar(dto);
            return Ok(true);
        }

        [HttpDelete("deletar/{id}")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<int>> Deletar(int id)
        {
            await _mensagemRepository.Deletar(id);
            return Ok(true);
        }

        [HttpGet("todos")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<List<MensagemDTO>>> GetTodos()
        {
            var todos = await _mensagemRepository.GetTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<MensagemDTO>> GetById(int id)
        {
            var porId = await _mensagemRepository.GetById(id);

            if (porId == null)
            {
                return NotFound();
            }

            return Ok(porId);
        }

        [HttpPost("enviarMensagem")]
        public async Task<ActionResult<RespostaDTO>> EnviarMensagem(MensagemDTO dto)
        {
            dto.UsuarioId = Convert.ToInt32(User?.FindFirstValue(ClaimTypes.NameIdentifier)) > 0 ? Convert.ToInt32(User?.FindFirstValue(ClaimTypes.NameIdentifier)) : null;
            var resposta = await _mensagemRepository.EnviarMensagem(dto);

            return Ok(resposta);
        }
    }
}
