using SharedApiCore.Domain.Entities;

namespace SharedApiCore.Domain.Contracts
{
    public interface IPessoaService : IDisposable
    {
        Task<bool> Adicionar(Pessoa pessoa);
        Task<bool> Atualizar(Pessoa pessoa);
        Task<bool> Remover(Guid id);
    }
}
