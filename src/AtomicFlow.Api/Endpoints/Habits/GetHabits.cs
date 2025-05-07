using AtomicFlow.Api.Abstractions;
using AtomicFlow.Contracts.Habits;
using AtomicFlow.Domain.Habits;
using Days = AtomicFlow.Domain.Habits.Days;

namespace AtomicFlow.Api.Endpoints.Habits;

internal sealed class GetHabits : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        // Testing
        app.MapGet("habits", () =>
        {
            return Results.Ok(CreateDummyGetHabitsResponse());
        });
    }
    
    private GetHabitsResponse CreateDummyGetHabitsResponse()
    {
        return new GetHabitsResponse([
            new(Guid.NewGuid(), Guid.NewGuid(), "Meditation", "Minutes", [DaysResponse.Monday, DaysResponse.Tuesday]),
            new(Guid.NewGuid(), Guid.NewGuid(), "Running", "Kilometers", [DaysResponse.Wednesday, DaysResponse.Friday]),
            new(Guid.NewGuid(), Guid.NewGuid(), "Reading", "Pages", [DaysResponse.Thursday, DaysResponse.Sunday]),
            new(Guid.NewGuid(), Guid.NewGuid(), "Workout", "Reps", [DaysResponse.Monday, DaysResponse.Saturday]),
            new(Guid.NewGuid(), Guid.NewGuid(), "Journaling", "Entries", [DaysResponse.Tuesday, DaysResponse.Thursday])
        ]);
    }

}
