namespace bicicletario.Application.Exceptions;

public class ApiException : Exception
{
    public int StatusCode { get; set; }
    public string UserFriendlyMessage { get; set; }

    public ApiException(string message, int statusCode = 500, string userFriendlyMessage = null!) : base(message)
    {
        StatusCode = statusCode;
        UserFriendlyMessage = userFriendlyMessage ?? "Ocorreu um erro inesperado.";
    }
}