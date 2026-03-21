using AuthService.Domain.Entities;
using AuthService.Infrastructure.Persistence.Entities;
using AutoMapper;

namespace AuthService.Infrastructure.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserEntity>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
             .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.username.name))
             .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.password.password))
             .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email.address))
             .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.address))
             .ForMember(dest => dest.CreadetDate, opt => opt.MapFrom(src => src.CreadetDate));
        }
    }
}
