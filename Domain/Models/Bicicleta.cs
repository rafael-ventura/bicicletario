namespace BicicletarioAPI.Domain;

public class Bicicleta
{
    public int Id { get; set; }
    public string Modelo { get; set; } = null!;
    public string Cor { get; set; } = null!;
    
    public string Marca { get; set; } = null!;
    
}