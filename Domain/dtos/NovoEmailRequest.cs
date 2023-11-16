namespace bicicletario.Domain.dtos;

public record NovoEmailRequest
{
    public string? EnderecoEmail { get; init; }
    
    public string Assunto { get; init; } = null!;
    
    public string Mensagem { get; init; } = null!;
}
