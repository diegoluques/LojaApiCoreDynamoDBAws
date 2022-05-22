namespace CadastroApiCore.API.Dtos
{
    public class ProdutoUpdateDto : ProdutoInsertDto
    {
        public Guid ProdutoId { get; set; }
    }
}
