namespace bicicletario.Application.Exceptions;

public class TotemNaoEncontradoException : ApiException
{
    public TotemNaoEncontradoException(int totemId)
        : base($"Totem com ID {totemId} não foi encontrado.")
    {
        
    }
}
