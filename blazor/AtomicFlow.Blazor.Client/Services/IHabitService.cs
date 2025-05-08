using AtomicFlow.Contracts.Habits;

namespace AtomicFlow.Blazor.Client.Services;

public interface IHabitService
{
    Task<GetHabitsResponse?> CreateHabitAsync();
}