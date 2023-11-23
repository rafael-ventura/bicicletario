namespace bicicletario.Application.Exceptions;

public class ApiException : Exception
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public int StatusCode { get; set; }

    public ApiException(string message, int statusCode = 500) : base(message)
    {
        StatusCode = statusCode;
    }
}
