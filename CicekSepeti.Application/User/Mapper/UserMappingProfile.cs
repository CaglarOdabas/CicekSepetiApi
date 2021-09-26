using AutoMapper;
using CicekSepeti.Application.User.Commands;
using CicekSepeti.Application.User.Responses;

namespace CicekSepeti.Application.User.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CicekSepeti.Core.Entities.User, UserResponse>().ReverseMap();
            CreateMap<CicekSepeti.Core.Entities.User, CreateUserCommand>().ReverseMap();
        }
    }
}
