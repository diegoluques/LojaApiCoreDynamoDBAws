using AutoMapper;
using CadastroApiCore.API.Dtos;
using SharedApiCore.Domain.Entities;

namespace CadastroApiCore.API.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Pessoa, PessoaInsertDto>();
            CreateMap<Pessoa, PessoaUpdateDto>();
        }
    }
}
