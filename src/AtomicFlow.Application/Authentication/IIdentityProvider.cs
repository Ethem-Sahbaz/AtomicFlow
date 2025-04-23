namespace AtomicFlow.Application.Authentication;
internal interface IIdentityProvider
{
    Task<string> RegisterUserAsync(string userName, string email, string password);
}
