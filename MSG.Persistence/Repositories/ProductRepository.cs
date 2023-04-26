using Microsoft.EntityFrameworkCore;
using MSG.Application.Repositories;
using MSG.Domain.Entities;
using MSG.Persistence.Context;

namespace MSG.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(DataContext context) : base(context)
    {
    }
    
    public Task<List<Product>> GetOrderedByQuantityAsync(CancellationToken cancellationToken)
    {
        return Context.Products
            .OrderBy(o => o.Quantity)
            .ToListAsync(cancellationToken);
    }
}