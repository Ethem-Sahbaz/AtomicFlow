using AtomicFlow.Application.Features.Users.RegisterUser;
using Microsoft.Extensions.DependencyInjection;

namespace AtomicFlow.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IRegisterUserCommandService, RegisterUserCommandService>();
        
        return services;
    }
}