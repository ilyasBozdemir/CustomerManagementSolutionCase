namespace CustomerManagement.Domain.Results;

public class CommandResult : ActionResult
{
    public CommandResult(bool success, int statusCode, string[] errors = null)
        : base(success, statusCode, errors)
    {
    }
    public CommandResult()
    {

    }
}
public class CommandResult<T> : CommandResult
{
    public T Data { get; set; }

    public CommandResult(bool success, int statusCode, T data, string[] errors = null)
        : base(success, statusCode, errors)
    {
        Data = data;
    }
}
