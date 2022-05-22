using AutoMapper;

namespace CadastroApiCore.API.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new DtoToDomainMappingProfile());
                ps.AddProfile(new DomainToDtoMappingProfile());
            });
        }
    }
}
