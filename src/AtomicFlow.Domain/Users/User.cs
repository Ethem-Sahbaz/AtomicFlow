using AtomicFlow.SharedKernel;

namespace AtomicFlow.Domain.Users;
public sealed class User
{
    private User(Guid id, string username, string email)
    {
        Id = id;
        Username = username;
        Email = email;
    }

    public Guid Id { get; }
    public string Username { get; }
    public string Email { get; }

    public static Result<User> Create(string username, string email)
    {
        User newUser = new(Guid.NewGuid(), username, email);

        return newUser;
    }
}
