namespace bicicletario.Domain.Models;

public enum BicicletaStatus
{
    DISPONIVEL,
    EM_USO,
    NOVA,
    APOSENTADA,
    REPARO_SOLICITADO,
    EM_REPARO
}

public class Bicicleta
{
    public Bicicleta()
    {
        Status = BicicletaStatus.NOVA;
    }
    
    public int Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Ano { get; set; }
    public int Numero { get; set; }
    public BicicletaStatus Status { get; set; }
}
