using bicicletario.Domain.Models;

namespace bicicletario.Domain.dtos;

public record NovaBicicletaRequest
{
    public string marca { get; set; }
    
    public string modelo { get; set; }
    
    public string ano { get; set; }
    
    public int numero { get; set; }
    
    public BicicletaStatus status { get; set; }
}
