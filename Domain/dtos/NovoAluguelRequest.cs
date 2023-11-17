namespace bicicletario.Domain.dtos;

public record NovoAluguelRequest
{
    public int IdCiclista { get; set; }
    
    public int TrancaInicioId { get; set; }
}
