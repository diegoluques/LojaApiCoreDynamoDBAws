using Microsoft.AspNetCore.Http;
using SharedApiCore.Domain.Contracts;

namespace LojaApiCore.Integrations.Storage
{
    public class S3Service : IFileService
    {
        public FileServiceResult Save(IFormFile formFile, string chaveIdentificacaoStorage)
        {
            return new FileServiceResult { Url = $"s3://{chaveIdentificacaoStorage}" };
        }
    }
}