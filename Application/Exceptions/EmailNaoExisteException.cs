namespace bicicletario.Application.Exceptions;

public class EmailNaoExisteException : ApiException
{
    public EmailNaoExisteException()
        : base("Email não existe.", 422)
    {
    }
    
    public EmailNaoExisteException(string message)
        : base(message, 422)
    {
    }
    
}
