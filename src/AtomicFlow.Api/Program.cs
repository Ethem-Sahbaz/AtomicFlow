using AtomicFlow.Application;
using AtomicFlow.Application.Features.Users.RegisterUser;
using AtomicFlow.Infrastructure;

// 1. Setup Azure B2C for Blazor WASM Application
// 2. Configure Api authentication to accept azure b2c jwt
// 3. Setup a database
// 4. Add new users to database

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/", async (IRegisterUserCommandService commandService) =>
    {
        await commandService.RegisterAsync(new RegisterUserRequest(
            "TestUser", "test@test.com", "Test1231!"));
    })
    .WithName("Root");

app.Run();