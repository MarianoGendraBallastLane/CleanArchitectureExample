using MediatR;

namespace MSG.Application.Features.ProductFeatures.UpdateProduct;

public sealed record UpdateProductRequest(
    Guid Id,
    string Name, 
    string Description, 
    int Quantity) : IRequest<UpdateProductResponse>;