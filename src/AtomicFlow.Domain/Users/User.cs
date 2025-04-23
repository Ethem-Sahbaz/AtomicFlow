using AtomicFlow.SharedKernel;

namespace AtomicFlow.Domain.Users;
public sealed class User
{
    private User(string username, string email)
    {
        Username = username;
        Email = email;
    }

    public Guid Id { get; }
    public string Username { get; }
    public string Email { get; }

    public static Result<User> Create(string username, string email)
    {
        User newUser = new User(username, email);

        return newUser;
    }


}
