using AutoMapper;
using MSG.Domain.Entities;

namespace MSG.Application.Features.ProductFeatures.UpdateProduct;

public sealed class UpdateProductMapper : Profile
{
    public UpdateProductMapper()
    {
        CreateMap<UpdateProductRequest, Product>();
        CreateMap<Product, UpdateProductResponse>();
    }
}