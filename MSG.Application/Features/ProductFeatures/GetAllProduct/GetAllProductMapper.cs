using AutoMapper;
using MSG.Domain.Entities;

namespace MSG.Application.Features.ProductFeatures.GetAllProduct;

public sealed class GetAllProductMapper : Profile
{
    public GetAllProductMapper()
    {
        CreateMap<Product, GetAllProductResponse>();
    }
}