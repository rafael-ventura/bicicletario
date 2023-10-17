using BicicletarioAPI.BicicletarioAPI.Domain;

namespace BicicletarioAPI.BicicletarioAPI.Application;

public class BicicletaService
{
    public Bicicleta ObterBicicleta(int id)
    {
        // Por simplicidade, retornaremos uma bicicleta fixa
        return new Bicicleta { Id = id, Modelo = "Mountain Bike", Cor = "Vermelho" };
    }
}
