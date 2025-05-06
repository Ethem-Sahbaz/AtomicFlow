using AtomicFlow.Blazor.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthenticationStateDeserialization();
builder.Services.AddScoped<IHabitService, HabitsService>();

builder.Services.AddHttpClient(nameof(HabitsService), config =>
{
    config.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

await builder.Build().RunAsync();
