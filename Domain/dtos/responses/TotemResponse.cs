using bicicletario.Domain.Models;

namespace bicicletario.Domain.dtos.responses;

public class TotemResponse
{
    public string Mensagem { get; set; } = null!;

    public IEnumerable<Totem>? Totens { get; set; }

    public Totem? Totem { get; set; }
}
