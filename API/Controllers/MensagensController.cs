using API.DTOs;
using API.Enums;
using API.Filters;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<List<MensagemDTO>>> GetTodos()
        {
            var todos = await _mensagemRepository.GetTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MensagemDTO>> GetById(int id)
        {
            var porId = await _mensagemRepository.GetById(id);

            if (porId == null)
            {
                return NotFound();
            }

            return Ok(porId);
        }
    }
}
