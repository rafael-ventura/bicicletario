namespace bicicletario.Domain.Models;

public enum BicicletaStatus
{
    Disponivel,
    EmUso,
    Nova,
    Aposentada,
    ReparoSolicitado,
    EmReparo
}

public class Bicicleta
{
    public Bicicleta()
    {
        Ano = DateTime.Now.Year.ToString();
        Status = BicicletaStatus.Nova;
    }
    
    public int Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Ano { get; set; }
    public int Numero { get; set; }
    public BicicletaStatus Status { get; set; }
}
