using MSG.Domain.Entities;

namespace MSG.Application.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<List<Product>> GetOrderedByQuantityAsync(CancellationToken cancellationToken);
}