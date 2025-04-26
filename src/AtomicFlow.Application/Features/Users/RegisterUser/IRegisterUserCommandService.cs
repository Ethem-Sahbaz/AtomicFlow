using AtomicFlow.Domain.Users;
using AtomicFlow.SharedKernel;

namespace AtomicFlow.Application.Features.Users.RegisterUser;

public interface IRegisterUserCommandService
{
    Task<Result<User>> RegisterAsync(RegisterUserRequest request);
}