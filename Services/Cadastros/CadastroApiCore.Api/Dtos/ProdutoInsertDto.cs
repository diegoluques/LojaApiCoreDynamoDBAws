using System.ComponentModel.DataAnnotations;

namespace CadastroApiCore.API.Dtos
{
    public class ProdutoInsertDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 50)]
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string? UrlImagem { get; set; }
    }
}
