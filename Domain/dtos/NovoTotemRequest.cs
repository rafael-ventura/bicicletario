namespace bicicletario.Domain.dtos;

public record NovoTotemRequest
{
    public string localizacao { get; set; }
    public string descricao { get; set; }
}
