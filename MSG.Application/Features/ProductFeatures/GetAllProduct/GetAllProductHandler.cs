using AutoMapper;
using MediatR;
using MSG.Application.Repositories;

namespace MSG.Application.Features.ProductFeatures.GetAllProduct;

public sealed class GetAllProductHandler : IRequestHandler<GetAllProductRequest, List<GetAllProductResponse>>
{
    private readonly IProductRepository _ProductRepository;
    private readonly IMapper _mapper;

    public GetAllProductHandler(IProductRepository ProductRepository, IMapper mapper)
    {
        _ProductRepository = ProductRepository;
        _mapper = mapper;
    }
    
    public async Task<List<GetAllProductResponse>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
    {
        var Products = await _ProductRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllProductResponse>>(Products);
    }
}