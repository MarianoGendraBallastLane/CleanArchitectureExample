using AutoMapper;
using MediatR;
using MSG.Application.Repositories;
using MSG.Domain.Entities;

namespace MSG.Application.Features.ProductFeatures.DeleteProduct;

public sealed class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public DeleteProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);

        var entityExists = await _productRepository.EntityExistsAsync(product);

        if (!entityExists)
            return new DeleteProductResponse
            {
                Deleted = false,
                Result = $"Record {product.Id} Not Found"
            };

        _productRepository.Delete(product);
        await _unitOfWork.Save(cancellationToken);
        return new DeleteProductResponse
        {
            Deleted = true
        };
    }
}