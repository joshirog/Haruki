using AutoMapper;
using Haruki.Api.Commons.Enums;
using Haruki.Api.Domains.Entities;

namespace Haruki.Api.Features.v1.Authentication.SignUp;

public class SignUpMapper : Profile
{
    public SignUpMapper()
    {
        CreateMap<SignUpCommand, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(StatusEnum), StatusEnum.Active)));
    }
}