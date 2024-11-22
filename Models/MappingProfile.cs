using AutoMapper;
using Register.Models.DTO;



namespace Register.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserUpdateDto>();
            CreateMap<Entity, EntityDto>(); // Mapping de Entity vers EntityDto
            CreateMap<EntityDto, Entity>(); // // Exemple de mapping de User vers UserUpdateDto

            // Vous pouvez ajouter d'autres mappings ici si nécessaire
        }
    }
}
