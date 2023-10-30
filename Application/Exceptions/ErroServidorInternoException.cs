namespace BicicletarioAPI.Application.Exceptions;

public class ErroServidorInternoException : ApiException
{
    public ErroServidorInternoException(string message) : base(message, 500)
    {
    }
}
