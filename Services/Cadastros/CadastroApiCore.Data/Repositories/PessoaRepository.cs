using Amazon.DynamoDBv2.DataModel;
using SharedApiCore.Data.Repositories;
using SharedApiCore.Domain.Contracts.Repositories;
using SharedApiCore.Domain.Entities;

namespace CadastroApiCore.Data.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    { 
        public PessoaRepository(IDynamoDBContext context) : base(context)
        {
        } 
    }
}
