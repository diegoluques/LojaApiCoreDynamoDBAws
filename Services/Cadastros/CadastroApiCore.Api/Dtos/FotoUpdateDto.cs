namespace CadastroApiCore.API.Dtos
{
    public class FotoUpdateDto : FotoInsertDto
    {
        public Guid PessoaId { get; set; }
    }
}
