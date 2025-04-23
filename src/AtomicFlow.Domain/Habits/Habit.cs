using AtomicFlow.SharedKernel;

namespace AtomicFlow.Domain.Habits;
public sealed class Habit
{
    private readonly HashSet<Days> _days = [];

    public Habit(Guid id, Guid userId, string name, string unitName)
    {
        Id = id;
        UserId = userId;
        Name = name;
        UnitName = unitName;
    }

    public Guid Id { get; }
    public Guid UserId { get; }
    public string Name { get; }
    public string UnitName { get; }
    public IReadOnlyCollection<Days> Days => _days.ToList();

    public static Result<Habit> Create(Guid userId,string name, string unitName, IEnumerable<Days> days)
    {
        Habit newHabit = new(Guid.NewGuid(), userId, name, unitName);

        foreach (var day in days)
        {
            newHabit._days.Add(day);
        }

        return newHabit;
    }
}
