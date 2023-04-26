using FluentValidation;

namespace MSG.Application.Features.ProductFeatures.CreateProduct;

public sealed class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(100);
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1);
    }
}