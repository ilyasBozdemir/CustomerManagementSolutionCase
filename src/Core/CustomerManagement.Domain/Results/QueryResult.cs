namespace CustomerManagement.Domain.Results;

public class QueryResult : ActionResult
{
    public object Data { get; set; }
    public QueryResult(bool success, int statusCode, string[] errors = null)
        : base(success, statusCode, errors)
    {
    }
    public QueryResult(bool success, int statusCode, object data, string[] errors = null)
      : base(success, statusCode, errors)
    {
        Data = data;
    }
    public QueryResult() { }
}


public class QueryResult<T> : ActionResult
{
    public T Data { get; set; }

    public QueryResult(bool success, int statusCode, string[] errors = null)
        : base(success, statusCode, errors)
    {
    }
    public QueryResult(bool success, int statusCode, T data, string[] errors = null)
        : base(success, statusCode, errors)
    {
        Data = data;
    }
    public QueryResult() { }
}
