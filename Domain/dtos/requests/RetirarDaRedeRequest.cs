namespace bicicletario.Domain.dtos.requests;

public record RetirarDaRedeRequest
{
    public int IdTranca { get; set; }
    public int IdBicicleta { get; set; }
    public int IdFuncionario { get; set; }
    public string StatusAcaoReparador { get; set; } = null!;
    
}