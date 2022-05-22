using Amazon.DynamoDBv2.DataModel;
using SharedApiCore.Domain.Bases;
using SharedApiCore.Domain.Contracts.Repositories;

namespace SharedApiCore.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly IDynamoDBContext _context;
        protected readonly List<ScanCondition> FilterAllRecords = new();

        public Repository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var result = await _context.ScanAsync<TEntity>(FilterAllRecords).GetRemainingAsync();
            return result;
        }

        public async Task<TEntity> GetId(Guid id)
        {
            var entity = await _context.LoadAsync<TEntity>(id);
            return entity;
        }

        public async Task<TEntity> Save(TEntity entity)
        {
            await _context.SaveAsync(entity);
            return entity;
        }

        public async Task Delete(Guid id)
        {
            await _context.DeleteAsync<TEntity>(id);
        }
    }
}
