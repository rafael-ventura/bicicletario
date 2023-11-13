namespace bicicletario.Domain.Models;

public enum TrancaStatus
{
LIVRE, 
OCUPADA, 
NOVA, 
APOSENTADA, 
EM_REPARO
}

public class Tranca
{
    public int Id { get; set; }
    public int NumeroBicicleta { get; set; }
    public string Localizacao { get; set; } = string.Empty;
    public string AnoDeFabricacao { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public TrancaStatus Status { get; set; }
}
