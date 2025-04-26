using AtomicFlow.Application.Authentication;
using AtomicFlow.Domain.Users;
using AtomicFlow.Infrastructure.Database.Repositories;
using AtomicFlow.Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AtomicFlow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IIdentityProvider, IdentityProvider>();
        services.AddTransient<IUserRepository, UserRepository>();
        
        return services;
    }
}