using SharedApiCore.Domain.DataTransferObjects;
using SharedApiCore.Domain.Entities;

namespace SharedApiCore.Domain.Contracts
{
    public interface IPessoaService : IBaseService<Pessoa>
    {
        Task<Pessoa> SavePhoto(PessoaInsertPhotoDto entity);
    }
}
