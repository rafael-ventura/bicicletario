namespace bicicletario.Application.Exceptions;

public class FuncionarioNaoAutorizadoException : ApiException
{
    public FuncionarioNaoAutorizadoException(int funcionarioId)
        : base($"Funcionario com ID {funcionarioId} não está autorizado a realizar essa ação.")
    {
    }

    public FuncionarioNaoAutorizadoException()
        : base("Funcionario não está autorizado a realizar essa ação.")
    {
    }
}
