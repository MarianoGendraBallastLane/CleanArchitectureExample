using FluentValidation;

namespace MSG.Application.Features.UserFeatures.LoginUser;

public sealed class LoginUserValidator : AbstractValidator<LoginUserRequest>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("Your password cannot be empty");
    }
}