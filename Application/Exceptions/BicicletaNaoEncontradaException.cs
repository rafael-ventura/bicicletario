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

public class BicicletaNaoDisponivelException : ApiException
{
    public BicicletaNaoDisponivelException(int bicicletaId)
        : base($"Bicicleta com ID {bicicletaId} não está disponível.")
    {
    }

    public BicicletaNaoDisponivelException()
        : base("Nenhuma bicicleta está disponível.")
    {
    }
}