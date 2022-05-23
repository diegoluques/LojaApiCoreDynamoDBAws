using SharedApiCore.Domain.Contracts;
using SharedApiCore.Domain.Contracts.Repositories;
using SharedApiCore.Domain.DataTransferObjects;
using SharedApiCore.Domain.Entities;

namespace CadastroApiCore.Domain.Services
{
    public class PessoaService : IPessoaService 
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IFileService _fileService;

        public PessoaService(IPessoaRepository pessoaRepository, IFileService fileService)
        {
            _pessoaRepository = pessoaRepository;
            _fileService = fileService;
        }

        Task<IEnumerable<Pessoa>> IBaseService<Pessoa>.GetAll()
        {
            return this._pessoaRepository.GetAll();
        }

        Task<Pessoa> IBaseService<Pessoa>.GetId(Guid id)
        {
            return this._pessoaRepository.GetId(id);
        }

        Task<Pessoa> IBaseService<Pessoa>.Save(Pessoa entity)
        {
            return this._pessoaRepository.Save(entity);
        }

        Task IBaseService<Pessoa>.Delete(Guid id)
        {
            return this._pessoaRepository.Delete(id);
        }

        public Task<Pessoa> SavePhoto(PessoaInsertPhotoDto entity)
        {
            var pessoa = new Pessoa
            {
                NomePessoa = entity.NomePessoa,
                Telefone = entity.Telefone, 
            };
            foreach (var file in entity.Fotos)
            {
                var foto = Foto.Create(); 
                foto.NomeArquivo = file.FileName;
                foto.TipoArquivo = file.ContentType;

                var fileServiceResult = _fileService.Save(file, foto.FotoId.ToString());
                foto.Caminho = fileServiceResult.Url;

                pessoa?.Fotos?.Add(foto);
            }

            return this._pessoaRepository.Save(pessoa);
        }
    }
}