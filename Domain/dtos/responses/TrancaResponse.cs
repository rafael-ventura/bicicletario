using bicicletario.Domain.Models;

namespace bicicletario.Domain.dtos.responses;

public class TrancaResponse
{
    public string Mensagem { get; set; } = null!;
    
    public IEnumerable<Tranca>? Trancas { get; set; }
    
    public Tranca? Tranca { get; set; }
}
