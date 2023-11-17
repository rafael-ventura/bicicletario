using bicicletario.Domain.Models;

namespace bicicletario.Domain.dtos;

public record NovaBicicletaRequest
{
    public string Marca { get; set; } = string.Empty;
    
    public string Modelo { get; set; } = string.Empty;
    
    public string Ano { get; set; } = string.Empty;
    
    public int Numero { get; set; }
    
    public BicicletaStatus Status { get; set; }
}
