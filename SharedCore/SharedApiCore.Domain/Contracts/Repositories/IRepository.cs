using SharedApiCore.Domain.Bases;

namespace SharedApiCore.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetId(Guid id);
        Task<TEntity> Save(TEntity entity);
        Task Delete(Guid id);
    }
}
