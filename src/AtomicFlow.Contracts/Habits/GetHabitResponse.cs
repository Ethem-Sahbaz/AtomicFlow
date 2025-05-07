namespace AtomicFlow.Contracts.Habits;


public sealed record GetHabitResponse(
    Guid Id,
    Guid UserId,
    string Name,
    string UnitName,
    IEnumerable<DaysResponse> Days);