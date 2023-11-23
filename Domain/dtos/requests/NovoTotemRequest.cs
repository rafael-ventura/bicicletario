namespace bicicletario.Domain.dtos;

public record NovoTotemRequest
{
    public string Localizacao { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
}
