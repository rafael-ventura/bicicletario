using bicicletario.Domain.enums;

namespace bicicletario.Domain.Models;

public class Cobranca
{
    public int Id { get; set; }

    public CobrancaStatusEnum Status { get; set; } = CobrancaStatusEnum.PENDENTE;

    public string HoraSolicitacao { get; set; } = null!;

    public string HoraFinalizacao { get; set; } = null!;

    public decimal Valor { get; set; }

    public int CiclistaId { get; set; }
}
