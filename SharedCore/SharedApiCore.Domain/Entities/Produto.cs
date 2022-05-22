using Amazon.DynamoDBv2.DataModel;
using SharedApiCore.Domain.Bases;

namespace SharedApiCore.Domain.Entities
{
    [DynamoDBTable("Produtos")]
    public class Produto : EntityBase
    {
        public Produto()
        {
            ProdutoId = Guid.NewGuid();
        }

        public Guid ProdutoId { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public string UrlImage { get; set; }
    }
}
