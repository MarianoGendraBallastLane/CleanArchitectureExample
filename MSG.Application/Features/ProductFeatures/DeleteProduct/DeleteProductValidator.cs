using FluentValidation;

namespace MSG.Application.Features.ProductFeatures.DeleteProduct;

public sealed class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Id).NotEqual(Guid.Empty);
    }
}