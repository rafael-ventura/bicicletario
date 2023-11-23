namespace bicicletario.Application.Exceptions;

public class FuncionarioNaoAutorizadoException : ApiException
{
    public FuncionarioNaoAutorizadoException()
        : base("Funcionario não está autorizado a realizar essa ação.")
    {
    }
}
