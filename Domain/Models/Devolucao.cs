namespace bicicletario.Domain.Models;

public class Devolucao
{
    public int BicicletaId { get; set; }
    
    public string HoraInicio { get; set; } = null!;

    public string HoraFim { get; set; } = null!;

    public int CiclistaId { get; set; }

    public int TrancaFimId { get; set; }
}
