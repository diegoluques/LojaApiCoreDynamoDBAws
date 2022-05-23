using Amazon.DynamoDBv2.DataModel;
using SharedApiCore.Domain.Bases;
using SharedApiCore.Domain.Exceptions;

namespace SharedApiCore.Domain.Entities
{
    [DynamoDBTable("Pessoas")]
    public class Pessoa : EntityBase
    {
        public Pessoa(string nomePessoa)  
        {
            PessoaId = Guid.NewGuid();
            NomePessoa = nomePessoa;
        }

        public Pessoa(Guid idPessoa, string nomePessoa)
        {
            PessoaId = idPessoa;
            NomePessoa = nomePessoa;
        }

        public Pessoa()
        {
            PessoaId = Guid.NewGuid();
            Fotos = new List<Foto>();
        }

        public Guid PessoaId { get; set; }

        public string NomePessoa { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        public IList<Foto>? Fotos { get; set; }

        public void ModificarNomePessoa(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new DomainException("O nome da pessoa é obrigatório");
            }

            NomePessoa = nome;
        }
    }
}