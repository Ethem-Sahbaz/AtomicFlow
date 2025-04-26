using AtomicFlow.Application.Authentication;

namespace AtomicFlow.Infrastructure.Identity;

public class IdentityProvider : IIdentityProvider
{
    public Task<string> RegisterUserAsync(string userName, string email, string password)
    {
        return Task.FromResult("TestId");
    }
}