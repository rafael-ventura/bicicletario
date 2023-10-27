// ReSharper disable once RedundantUsingDirective

using BicicletarioAPI.Domain;

namespace BicicletarioAPI.Application;

public class BicicletaService
{
    public Bicicleta ObterBicicleta(int id)
    {
        // Por simplicidade, retornarmos uma bicicleta fixa
        return new Bicicleta { Id = id, Modelo = "Mountain Bike", Cor = "Vermelho", Marca = "Caloi" };
    }
}
