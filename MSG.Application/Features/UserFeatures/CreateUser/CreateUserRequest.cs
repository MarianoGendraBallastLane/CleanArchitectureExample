using MediatR;

namespace MSG.Application.Features.UserFeatures.CreateUser;

public sealed record CreateUserRequest(
    string Email, 
    string Name, 
    string Password,
    string PasswordConfirm) : IRequest<CreateUserResponse>;