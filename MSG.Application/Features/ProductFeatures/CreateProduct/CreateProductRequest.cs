using MediatR;

namespace MSG.Application.Features.ProductFeatures.CreateProduct;

public sealed record CreateProductRequest(string Name, string Description, int Quantity) : IRequest<CreateProductResponse>;