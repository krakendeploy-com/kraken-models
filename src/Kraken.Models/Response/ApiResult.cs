namespace Kraken.Shared.Response;

public record ApiResult<T>(
    T? Data,
    string? ErrorMessage,
    ResultType ResultType,
    string ContentType = "application/json",
    string? ContentDisposition = null,
    Dictionary<string, string>? Headers = null
) where T : class?
{
    public static ApiResult<T> Success(T data)
    {
        return new ApiResult<T>(data, null, ResultType.Success);
    }

    public static ApiResult<T> Success(T data, string contentType, string? contentDisposition)
    {
        return new ApiResult<T>(data, null, ResultType.Success, contentType, contentDisposition);
    }

    public static ApiResult<T> Created(T data)
    {
        return new ApiResult<T>(data, null, ResultType.Created);
    }

    public static ApiResult<T> Error(string? errorMessage = null)
    {
        return new ApiResult<T>(null, errorMessage, ResultType.Error);
    }

    public static ApiResult<T> NotFound(string? errorMessage = null)
    {
        return new ApiResult<T>(null, errorMessage, ResultType.NotFound);
    }

    public static ApiResult<T> ValidationError(string? errorMessage = null)
    {
        return new ApiResult<T>(null, errorMessage, ResultType.ValidationError);
    }

    public static ApiResult<T> Unauthorized(string? errorMessage = null)
    {
        return new ApiResult<T>(null, errorMessage, ResultType.Unauthorized);
    }

    public static ApiResult<T> Forbidden(string? errorMessage = null)
    {
        return new ApiResult<T>(null, errorMessage, ResultType.Forbidden);
    }

    public static ApiResult<T> NoContent()
    {
        return new ApiResult<T>(null, null, ResultType.NoContent);
    }

    public static ApiResult<T> Conflict(Dictionary<string, string>? headers = null)
    {
        return new ApiResult<T>(null, null, ResultType.Conflict, Headers: headers);
    }

    public static ApiResult<T> Accepted(T data)
    {
        return new ApiResult<T>(data, null, ResultType.Accepted);
    }
}

public record Result(
    string? ErrorMessage,
    ResultType ResultType
)
{
    public static Result Success()
    {
        return new Result(null, ResultType.Success);
    }

    public static Result Created()
    {
        return new Result(null, ResultType.Created);
    }

    public static Result Error(string? errorMessage = null)
    {
        return new Result(errorMessage, ResultType.Error);
    }

    public static Result NotFound(string? errorMessage = null)
    {
        return new Result(errorMessage, ResultType.NotFound);
    }

    public static Result ValidationError(string? errorMessage = null)
    {
        return new Result(errorMessage, ResultType.ValidationError);
    }

    public static Result Unauthorized(string? errorMessage = null)
    {
        return new Result(errorMessage, ResultType.Unauthorized);
    }

    public static Result Forbidden(string? errorMessage = null)
    {
        return new Result(errorMessage, ResultType.Forbidden);
    }

    public static Result NoContent()
    {
        return new Result(null, ResultType.NoContent);
    }

    public static Result Accepted()
    {
        return new Result(null, ResultType.Accepted);
    }
}

public enum ResultType
{
    Success,
    Created,
    Error,
    NotFound,
    ValidationError,
    Unauthorized,
    Forbidden,
    NoContent,
    Conflict,
    Accepted
}