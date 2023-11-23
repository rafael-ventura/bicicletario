namespace bicicletario.Application.Exceptions;

public class TrancaNaoEncontradaException : ApiException
{
    public TrancaNaoEncontradaException(int trancaId)
        : base($"Tranca com ID {trancaId} não foi encontrada.", 404)
    {
        
    }
    
    public TrancaNaoEncontradaException()
        : base("Nenhuma tranca foi encontrada.")
    {
        
    }
}


public class TrancaNaoDisponivelException : ApiException
{
    public TrancaNaoDisponivelException(int trancaId)
        : base($"Tranca com ID {trancaId} não está disponível.")
    {
    }
}