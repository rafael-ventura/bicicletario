namespace bicicletario.Domain.dtos;

public record NovaCobrancaRequest
{
    public decimal Valor { get; set; }

    public int CiclistaId { get; set; }
}
