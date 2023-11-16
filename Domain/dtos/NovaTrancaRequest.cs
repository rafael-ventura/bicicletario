using bicicletario.Domain.Models;

namespace bicicletario.Domain.dtos;

public class NovaTrancaRequest
{
    public int numero { get; set; }
    
    public string localizacao { get; set; }
    
    public string anoDeFabricacao { get; set; }
    
    public string modelo { get; set; }
    
    public TrancaStatus status { get; set; }
}
