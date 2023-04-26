using FluentValidation;

namespace MSG.Application.Features.ProductFeatures.UpdateProduct;

public sealed class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Id).NotEqual(Guid.Empty);
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(100);
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1);
    }
}