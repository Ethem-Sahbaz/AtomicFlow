namespace AtomicFlow.Application.Authentication;
public interface IIdentityProvider
{
    Task<string> RegisterUserAsync(string userName, string email, string password);
}
