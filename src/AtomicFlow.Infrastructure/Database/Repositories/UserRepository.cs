using AtomicFlow.Domain.Users;

namespace AtomicFlow.Infrastructure.Database.Repositories;

internal sealed class UserRepository : IUserRepository
{
    public void Insert(User user)
    {
        
    }

    public Task<bool> EmailExists(string email)
    {
        return Task.FromResult(false);
    }
}