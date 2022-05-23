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
            //CreateMap<Pessoa, PessoaInsertPhotoDto>();
            CreateMap<Pessoa, PessoaUpdatePhotoDto>();

            CreateMap<Foto, FotoInsertDto>();
            CreateMap<Foto, FotoUpdateDto>();

            CreateMap<Produto, ProdutoInsertDto>();
            CreateMap<Produto, ProdutoUpdateDto>();
        }
    }
}
