using AtomicFlow.Domain.Users;
using AtomicFlow.SharedKernel;

namespace AtomicFlow.Application.Features.Users;
internal sealed class RegisterUserCommandService
{
    private readonly IUserRepository _userRepository;


    public async Task<Result<User>> Register(RegisterUserRequest request)
    {
        bool emailExists = await _userRepository.EmailExists(request.Email);

        if (emailExists)
        {
            return Result.Failure<User>(UserErrors.EmailAlreadyExists);
        }





        return null;
    }
}

public record RegisterUserRequest(string Username, string Email, string Password);
