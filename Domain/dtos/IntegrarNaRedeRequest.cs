namespace bicicletario.Domain.dtos;

public record IntegrarNaRedeRequest
{
    public int IdTranca { get; set; }
    
    public int IdBicicleta { get; set; }
    
    public int IdFuncionario { get; set; }
}
