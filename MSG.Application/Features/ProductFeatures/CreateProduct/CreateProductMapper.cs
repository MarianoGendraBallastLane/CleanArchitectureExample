using AutoMapper;
using MSG.Domain.Entities;

namespace MSG.Application.Features.ProductFeatures.CreateProduct;

public sealed class CreateProductMapper : Profile
{
    public CreateProductMapper()
    {
        CreateMap<CreateProductRequest, Product>();
        CreateMap<Product, CreateProductResponse>();
    }
}