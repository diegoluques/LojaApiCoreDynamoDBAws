using AutoMapper;
using CadastroApiCore.API.Dtos;
using SharedApiCore.Domain.Entities;

namespace CadastroApiCore.API.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<PessoaInsertDto, Pessoa>();
            CreateMap<PessoaUpdateDto, Pessoa>();
            //CreateMap<PessoaInsertPhotoDto, Pessoa>();
            CreateMap<PessoaUpdatePhotoDto, Pessoa>();

            CreateMap<FotoInsertDto, Foto>();
            CreateMap<FotoUpdateDto, Foto>();

            CreateMap<ProdutoInsertDto, Produto>();
            CreateMap<ProdutoUpdateDto, Produto>();
        }
    }
}
