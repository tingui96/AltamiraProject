using AutoMapper;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models;

namespace AltamiraProject
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserToUpdateDTO, User>();
        }
    }
}
