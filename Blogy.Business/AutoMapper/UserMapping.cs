using AutoMapper;
using Blogy.Business.DTOS.UserDtos;
using Blogy.Entities.Concrete;

namespace Blogy.Business.AutoMapper;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<AppUser, ResultUserDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => string.Join(" ", src.FirstName, src.LastName))).ReverseMap();
        CreateMap<AppUser, EditProfileDto>().ReverseMap();
    }
}
