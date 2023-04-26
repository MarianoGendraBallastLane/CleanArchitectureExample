using MediatR;

namespace MSG.Application.Features.UserFeatures.LoginUser;

public sealed record LoginUserRequest(
    string Email, 
    string Password) : IRequest<LoginUserResponse>;