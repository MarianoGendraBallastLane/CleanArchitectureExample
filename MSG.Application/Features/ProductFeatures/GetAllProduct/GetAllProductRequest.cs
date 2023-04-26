using MediatR;

namespace MSG.Application.Features.ProductFeatures.GetAllProduct;

public sealed record GetAllProductRequest : IRequest<List<GetAllProductResponse>>;