using AutoMapper;
using Entities.DTO;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models;

namespace Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserToUpdateDTO, User>();
            CreateMap<RegisterModel, User>();
            CreateMap<Role, RoleResponse>();
            CreateMap<User, UserWithDetail>();
        }
    }
}
