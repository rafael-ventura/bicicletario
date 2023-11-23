using bicicletario.Domain.Models;

namespace bicicletario.Domain.dtos;

public record RetirarDaRedeRequest
{
    public int IdTranca { get; set; }
    public int IdBicicleta { get; set; }
    public int IdFuncionario { get; set; }
    public string StatusAcaoReparador { get; set; } = null!;
    
}