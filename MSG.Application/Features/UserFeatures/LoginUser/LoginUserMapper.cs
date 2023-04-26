using AutoMapper;
using MSG.Domain.Entities;

namespace MSG.Application.Features.UserFeatures.LoginUser;

public sealed class LoginUserMapper : Profile
{
    public LoginUserMapper()
    {
        CreateMap<LoginUserRequest, User>();
        CreateMap<User, LoginUserResponse>();
    }
}