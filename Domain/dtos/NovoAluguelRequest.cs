namespace bicicletario.Domain.dtos;

public record NovoAluguelRequest
{
    public int idCiclista { get; set; }
    
    public int TrancaInicioId { get; set; }
}
