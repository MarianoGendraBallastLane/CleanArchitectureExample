using MediatR;

namespace MSG.Application.Features.ProductFeatures.DeleteProduct;

public sealed record DeleteProductRequest(Guid Id) : IRequest<DeleteProductResponse>;