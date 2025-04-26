namespace AtomicFlow.SharedKernel;
public record Error
{
    public static readonly Error None = new ("","");
    public static readonly Error NullValue = new("Errors.NullValue", "Null Value was provided");

    public Error(string code, string description)
    {
        Code = code;
        Description = description;
    }

    public string Code { get; }
    public string Description { get; }
}
