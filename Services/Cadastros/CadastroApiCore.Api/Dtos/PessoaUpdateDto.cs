namespace CadastroApiCore.API.Dtos
{
    public class PessoaUpdateDto : PessoaInsertDto
    {
        public Guid PessoaId { get; set; }
    }
}
