namespace bicicletario.Application.Exceptions;

public class DadosInvalidosException : ApiException
{
    public DadosInvalidosException()
        : base("Dados inválidos.", 422)
    {
    }
    
    public DadosInvalidosException(string message)
        : base(message, 422)
    {
    }
    
}
