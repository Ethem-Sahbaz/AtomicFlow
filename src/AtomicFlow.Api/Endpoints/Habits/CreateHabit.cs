using AtomicFlow.Api.Abstractions;
using AtomicFlow.Domain.Habits;

namespace AtomicFlow.Api.Endpoints.Habits;

internal sealed class CreateHabit : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        // Testing
        app.MapPost("habits", () =>
        {
            
            return Habit.Create(Guid.NewGuid(), "Test", "Minutes", [Days.Monday, Days.Friday]);
        });
    }
    
    private sealed record CreateHabitRequest(
        string Name,
        string UnitName,
        IReadOnlyCollection<Days> Days);
}
