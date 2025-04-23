namespace AtomicFlow.Domain.Users;
public interface IUserRepository
{
    void Insert(User user);
    Task<bool> EmailExists(string email);
}
