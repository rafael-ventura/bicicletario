namespace bicicletario.Application.Exceptions;

public class DadosInvalidosException : ApiException
{
    public DadosInvalidosException() : base("Dados inválidos", 400)
    {
    }

    public DadosInvalidosException(string message) : base(message, 400)
    {
    }
}
