namespace bicicletario.Domain.dtos;

public record NovaDevolucaoRequest
{
    public int IdCiclista { get; set; }
    
    public int TrancaFim { get; set; }
}
