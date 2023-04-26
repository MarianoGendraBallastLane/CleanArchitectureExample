namespace MSG.Application.Features.UserFeatures.LoginUser;

public sealed record LoginUserResponse
{
    public string Token { get; set; } = string.Empty;
}