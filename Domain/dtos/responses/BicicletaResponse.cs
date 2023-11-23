using bicicletario.Domain.Models;

namespace bicicletario.Domain.dtos.responses;

public record BicicletaResponse
{
    public string Mensagem { get; set; } = null!;
    public IEnumerable<Bicicleta>? Bicicletas { get; set; }
}
