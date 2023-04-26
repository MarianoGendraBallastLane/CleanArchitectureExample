using MSG.Domain.Entities;

namespace MSG.Application.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email, CancellationToken cancellationToken);
}