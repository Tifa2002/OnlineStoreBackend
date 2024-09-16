using AutoMapper;
using OnlineStore.Application.DTOs;
using OnlineStore.Infrastructure.DTOs;
using OnlineStore.Service.DTOs;
using OnlineStore.Service.Helper;


namespace OnlineStore.Infrastructure.Mappign
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserDTO>();
            CreateMap<Category,CategoriesDTO>().ReverseMap();
            CreateMap<IdentityRole,RoleDTO>().ReverseMap();
        }
    }
}
