namespace AtomicFlow.Domain.HabitEntries;
public sealed class HabitEntry
{
    public HabitEntry(Guid id, Guid habitId, double unitValue)
    {
        Id = id;
        HabitId = habitId;
        UnitValue = unitValue;
    }

    public Guid Id { get; }
    public Guid HabitId { get; }
    public double UnitValue { get; }
}
