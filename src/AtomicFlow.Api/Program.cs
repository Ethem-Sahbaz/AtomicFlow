using AtomicFlow.Api.Extensions;
using AtomicFlow.Application;
using AtomicFlow.Application.Features.Users.RegisterUser;
using AtomicFlow.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
// Provide assembly
builder.Services.AddEndpoints([typeof(Program).Assembly]);
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapEndpoints();


app.Run();