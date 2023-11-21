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
    }
    public Bicicleta(int id, string marca, string modelo, string ano, int numero, BicicletaStatus status)
    {
        Id = id;
        Marca = marca;
        Modelo = modelo;
        Ano = ano;
        Numero = numero;
        Status = status;
    }

    public int Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Ano { get; set; } = DateTime.Now.Year.ToString();
    public int Numero { get; set; }
    public BicicletaStatus Status { get; set; } = BicicletaStatus.Nova;
}
