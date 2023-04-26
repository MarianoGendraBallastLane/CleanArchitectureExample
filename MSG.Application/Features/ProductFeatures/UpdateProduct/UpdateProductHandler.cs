using AutoMapper;
using MediatR;
using MSG.Application.Repositories;
using MSG.Domain.Entities;

namespace MSG.Application.Features.ProductFeatures.UpdateProduct;

public sealed class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);

        var existingEntity = await _productRepository.Get(product.Id, cancellationToken);

        if (existingEntity != null)
        {
            existingEntity.Name = product.Name;
            existingEntity.Description = product.Description;
            existingEntity.Quantity = product.Quantity;
            
            _productRepository.Update(existingEntity);
            await _unitOfWork.Save(cancellationToken);

        }
        return _mapper.Map<UpdateProductResponse>(existingEntity);
    }
}