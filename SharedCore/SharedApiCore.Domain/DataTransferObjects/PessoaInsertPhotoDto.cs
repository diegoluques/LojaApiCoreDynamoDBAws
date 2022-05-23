using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SharedApiCore.Domain.DataTransferObjects
{
    public class PessoaInsertPhotoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string NomePessoa { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public IFormFileCollection Fotos { get; set; }
    }
}
