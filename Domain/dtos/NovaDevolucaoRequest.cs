namespace bicicletario.Domain.dtos;

public record NovaDevolucaoRequest
{
    public int IdTranca { get; set; }
    
    public int IdBicicleta { get; set; }
}
