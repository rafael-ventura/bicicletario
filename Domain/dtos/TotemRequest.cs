namespace bicicletario.Domain.dtos;

public record TotemRequest
{
    public string localizacao { get; set; }
    public string descricao { get; set; }
}
