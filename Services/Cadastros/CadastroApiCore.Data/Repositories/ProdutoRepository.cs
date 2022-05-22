using Amazon.DynamoDBv2.DataModel;
using SharedApiCore.Data.Repositories;
using SharedApiCore.Domain.Contracts.Repositories;
using SharedApiCore.Domain.Entities;

namespace CadastroApiCore.Data.Repositories
{
    internal class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IDynamoDBContext context) : base(context)
        {
        }
    }
}
