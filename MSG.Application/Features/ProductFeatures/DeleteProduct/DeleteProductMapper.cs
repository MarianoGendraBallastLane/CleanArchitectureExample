using AutoMapper;
using MSG.Domain.Entities;

namespace MSG.Application.Features.ProductFeatures.DeleteProduct;

public sealed class DeleteProductMapper : Profile
{
    public DeleteProductMapper()
    {
        CreateMap<DeleteProductRequest, Product>();
    }
}