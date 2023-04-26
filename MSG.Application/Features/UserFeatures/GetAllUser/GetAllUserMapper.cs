using AutoMapper;
using MSG.Domain.Entities;

namespace MSG.Application.Features.UserFeatures.GetAllUser;

public sealed class GetAllUserMapper : Profile
{
    public GetAllUserMapper()
    {
        CreateMap<User, GetAllUserResponse>();
    }
}