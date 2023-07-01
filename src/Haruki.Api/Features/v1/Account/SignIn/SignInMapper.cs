using AutoMapper;
using Haruki.Api.Domains.Entities;

namespace Haruki.Api.Features.v1.Account.SignIn;

public class SignInMapper : Profile
{
    public SignInMapper()
    {
        CreateMap<SignInCommand, User>();
    }
}