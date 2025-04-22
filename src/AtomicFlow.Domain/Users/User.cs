namespace AtomicFlow.Domain.Users;
internal sealed class User
{
    private User(string username, string email)
    {
        Username = username;
        Email = email;
    }

    public Guid Id { get; }
    public string Username { get; }
    public string Email { get; }


}
