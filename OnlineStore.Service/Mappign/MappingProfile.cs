using AutoMapper;
using OnlineStore.Infrastructure.DTOs;
using OnlineStore.Service.DTOs;


namespace OnlineStore.Infrastructure.Mappign
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserDTO>();
            CreateMap<Category,CategoriesDTO>().ReverseMap();
            
        }
    }
}
