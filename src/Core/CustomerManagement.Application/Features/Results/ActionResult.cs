namespace CustomerManagement.Application.Features.Results;

public class ActionResult
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public object? Data { get; set; }
    public bool IsError => Errors != null && Errors.Length > 0;

    public string[] Errors { get; set; }

    public ActionResult(
        bool success,
        int statusCode,
        string[] errors = null,
        object? data = null
    )
    {
        Success = success;
        StatusCode = statusCode;
        Errors = errors ?? Array.Empty<string>();
        Data = data;
    }

    public ActionResult()
    {
        Success = true;
        StatusCode = 200;
        Errors = Array.Empty<string>();
        Data = null;
    }
}