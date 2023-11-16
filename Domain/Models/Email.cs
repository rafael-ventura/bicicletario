namespace bicicletario.Domain.Models;

public class Email
{
    public int Id { get; set; }
    
    public string? EnderecoEmail { get; set; }
    
    public string Assunto { get; set; } = null!;
    
    public string Mensagem { get; set; } = null!;
}
