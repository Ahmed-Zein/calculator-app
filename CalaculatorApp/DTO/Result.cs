namespace CalculatorApp.DTO;

public interface IResult
{
    bool Success { get; }
    string Message { get; }
    object? Data { get; }
}

public class Result : IResult
{
    public bool Success { get; }
    public string Message { get; }
    public object? Data { get; }

    private Result(bool success, string message, object? data = null)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public static Result Ok(string message, object? data = null) => new Result(true, message, data);
    public static Result Err(string message, object? data = null) => new Result(false, message, data);
}