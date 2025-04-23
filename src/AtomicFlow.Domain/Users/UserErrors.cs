using AtomicFlow.SharedKernel;

namespace AtomicFlow.Domain.Users;
public static class UserErrors
{
    public static Error EmailAlreadyExists = new("Users.EmailAlreadyExists", "Provided Email already exists");
}
