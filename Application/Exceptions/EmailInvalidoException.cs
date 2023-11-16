namespace bicicletario.Application.Exceptions;

public class EmailInvalidoException : ApiException
{
    public EmailInvalidoException()
        : base("Email com formato inválido.", 422)
    {
        
        
    }
    
    public EmailInvalidoException(string message)
        : base(message, 422)
    {
    }
}

