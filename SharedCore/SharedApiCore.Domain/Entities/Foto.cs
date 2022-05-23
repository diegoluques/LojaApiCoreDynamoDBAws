using Amazon.DynamoDBv2.DataModel;
using SharedApiCore.Domain.Bases;

namespace SharedApiCore.Domain.Entities
{
    public class Foto : EntityBase
    {
        public Foto(string caminho)
        {
            FotoId = Guid.NewGuid();
            Caminho = caminho;
        }

        public Foto(Guid fotoId, string caminho)
        {
            FotoId = fotoId;
            Caminho = caminho;
        }

        public Foto()
        {
            FotoId = Guid.NewGuid();
        }

        public Guid FotoId { get; set; }
        public string Caminho { get; set; }
        public string NomeArquivo { get; set; }
        public string TipoArquivo { get; set; }

        public static Foto Create() => new();
    }
}
