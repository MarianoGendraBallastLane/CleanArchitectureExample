using MediatR;

namespace MSG.Application.Features.UserFeatures.GetAllUser;

public sealed record GetAllUserRequest : IRequest<List<GetAllUserResponse>>;