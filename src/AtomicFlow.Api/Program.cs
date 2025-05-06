using AtomicFlow.Application;
using AtomicFlow.Application.Features.Users.RegisterUser;
using AtomicFlow.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/habits", (HttpContext context) =>
    {
        return Results.Ok("Good");
    })
    .WithName("Habits");

app.Run();