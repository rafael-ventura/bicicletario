namespace bicicletario.Application.Exceptions;

public class BicicletaNaoEncontradaException : ApiException
{
    public BicicletaNaoEncontradaException(int bicicletaId)
        : base($"Bicicleta com ID {bicicletaId} não foi encontrada.")
    {
    }

    public BicicletaNaoEncontradaException()
        : base("Nenhuma bicicleta foi encontrada.")
    {
    }
    
    

}
