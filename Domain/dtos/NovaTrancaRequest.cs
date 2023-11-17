using bicicletario.Domain.Models;

namespace bicicletario.Domain.dtos;

public class NovaTrancaRequest
{
    public int Numero { get; set; } = 0;

    public string Localizacao { get; set; } = null!;

    public string AnoDeFabricacao { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public TrancaStatus Status { get; set; }
}
