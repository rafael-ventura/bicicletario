namespace bicicletario.Application.Exceptions;

public class CobrancaNaoEncontradaException : ApiException
{
    public CobrancaNaoEncontradaException() : base("Não encontrado", 404)
    {
    }
}
