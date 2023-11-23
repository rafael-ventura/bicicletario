namespace bicicletario.Domain.dtos.requests;

public record IntegrarNaRedeRequest
{
    public int IdTranca { get; set; }
    
    public int IdBicicleta { get; set; }
    
    public int IdFuncionario { get; set; }
}
