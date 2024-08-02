namespace DocPlannerTest.Entities.Core;

public class Result<T>(bool isSuccess, T value, string error = "")
{
    public bool IsSuccess { get; } = isSuccess;
    public T Value { get; } = value;
    public string Error { get; } = error;

    public static Result<T> Success(T value) => new(true, value);
    public static Result<T> Failure(string error) => new(false, default, error);
}