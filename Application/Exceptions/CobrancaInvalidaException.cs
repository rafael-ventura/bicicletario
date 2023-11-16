namespace bicicletario.Application.Exceptions;

public class CobrancaInvalidaException : ApiException

{
    public CobrancaInvalidaException()
        : base("Dados Invalidos.", 422)
    {
    }
}
