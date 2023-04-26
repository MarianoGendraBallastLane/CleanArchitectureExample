using MSG.Domain.Common;

namespace MSG.Application.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> EntityExistsAsync(T entity);
    Task<T> Get(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}