using AtomicFlow.Application;
using AtomicFlow.Application.Features.Users.RegisterUser;
using AtomicFlow.Infrastructure;

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