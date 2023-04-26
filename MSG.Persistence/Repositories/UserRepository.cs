using Microsoft.EntityFrameworkCore;
using MSG.Application.Repositories;
using MSG.Domain.Entities;
using MSG.Persistence.Context;

namespace MSG.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }
    
    public Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}