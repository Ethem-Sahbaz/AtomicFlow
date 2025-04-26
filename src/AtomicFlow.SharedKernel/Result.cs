namespace AtomicFlow.SharedKernel;
public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        if ((isSuccess && error != Error.None) ||
            (isSuccess == false && error == Error.None))
        {
            throw new ArgumentException("Provided parameter combination is invalid.");
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public Error Error { get; }
    public bool IsFailure => !IsSuccess;

    public static Result Success() =>
        new(true, Error.None);

    public static Result Failure(Error error) =>
        new(false, error);
    public static Result<TValue> Success<TValue>(TValue value) =>
        new(true, Error.None, value);

    public static Result<TValue> Failure<TValue>(Error error) =>
        new(false, error, default);

}

public class Result<TValue> : Result
{
    internal Result(bool isSuccess, Error error, TValue? value)
        : base(isSuccess, error)
    {
        _value = value;
    }

    private readonly TValue? _value;
    public TValue Value => _value is not null ?
        _value : throw new InvalidOperationException("Can not access a value of a failure result.");

    public static implicit operator Result<TValue> (TValue value) => value is not null?
        Result.Success(value) : Result.Failure<TValue>(Error.NullValue);
}
