using Microsoft.EntityFrameworkCore;
using MSG.Application.Repositories;
using MSG.Domain.Common;
using MSG.Persistence.Context;
using System.Collections.Generic;

namespace MSG.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DataContext Context;

    public BaseRepository(DataContext context)
    {
        Context = context;
    }

    public void Create(T entity)
    {
        entity.DateCreated = DateTimeOffset.UtcNow;
        Context.Add(entity);
    }

    public void Update(T entity)
    {
        entity.DateUpdated = DateTimeOffset.UtcNow;
        Context.Update(entity);
    }

    public void Delete(T entity)
    {
        var existingEntity = Context.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
        if (existingEntity != null)
        {
            existingEntity.DateDeleted = DateTimeOffset.UtcNow;
            Context.Entry(existingEntity).State = EntityState.Modified;
            Context.Update(existingEntity);
        }
    }

    public Task<T> Get(Guid id, CancellationToken cancellationToken)
    {
        return Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return Context.Set<T>().ToListAsync(cancellationToken);
    }

    public Task<bool> EntityExistsAsync(T entity)
    {
        return Context.Set<T>().AnyAsync(o => o.Id == entity.Id);
    }
}