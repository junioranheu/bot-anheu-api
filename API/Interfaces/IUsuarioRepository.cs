using API.DTOs;

namespace API.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioDTO>? Adicionar(UsuarioSenhaDTO dto);
        Task<UsuarioDTO>? Atualizar(UsuarioSenhaDTO dto);
        Task<List<UsuarioDTO>>? GetTodos();
        Task<UsuarioDTO>? GetById(int id);
        Task<UsuarioSenhaDTO>? GetByEmailOuUsuarioSistema(string? email, string? nomeUsuarioSistema);
    }
}
