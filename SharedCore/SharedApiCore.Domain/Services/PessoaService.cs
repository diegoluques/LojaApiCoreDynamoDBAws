using CadastroApiCore.Domain.Contracts;
using CadastroApiCore.Domain.Contracts.Repositories;
using CadastroApiCore.Domain.Entities;
using CadastroApiCore.Domain.Entities.Validations;

namespace CadastroApiCore.Domain.Services
{
    public class PessoaService : BaseService, IPessoaService
    {
        private readonly IPessoaRepository _PessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository, INotifier notificador) : base(notificador)
        {
            _PessoaRepository = pessoaRepository;
        }

        public async Task<bool> Adicionar(Pessoa Pessoa)
        {
            if (!ExecutarValidacao(new PessoaValidation(), Pessoa)) return false;

            await _PessoaRepository.Adicionar(Pessoa);
            return true;
        }

        public async Task<bool> Atualizar(Pessoa Pessoa)
        {
            if (!ExecutarValidacao(new PessoaValidation(), Pessoa)) return false;

            await _PessoaRepository.Atualizar(Pessoa);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _PessoaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _PessoaRepository?.Dispose();
        }
    }
}