using Microsoft.AspNetCore.Http;

namespace SharedApiCore.Domain.Contracts
{
    public interface IFileService
    {
        FileServiceResult Save(IFormFile formFile, string chaveIdentificacaoStorage);
    }

    public class FileServiceResult
    {
        public string Url { get; set; }
    }
}
