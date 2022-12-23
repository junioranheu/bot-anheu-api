using API.DTOs;

namespace API.Interfaces
{
    public interface IMensagemRepository
    {
        Task? Adicionar(MensagemDTO dto);
        Task? Atualizar(MensagemDTO dto);
        Task? Deletar(int id);
        Task<List<MensagemDTO>>? GetTodos();
        Task<MensagemDTO>? GetById(int id);
    }
}
