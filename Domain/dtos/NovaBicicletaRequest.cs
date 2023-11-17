using bicicletario.Domain.Models;

namespace bicicletario.Domain.dtos;

public record NovaBicicletaRequest
{
    public string Marca { get; set; } = null!;
    
    public string Modelo { get; set; } = null!;
    
    public string Ano { get; set; } = null!;
    
    public int Numero { get; set; } = 0;
    
    public BicicletaStatus Status { get; set; } = BicicletaStatus.DISPONIVEL;
}
