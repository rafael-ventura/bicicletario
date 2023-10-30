using BicicletarioAPI.Domain;

namespace BicicletarioAPI.Application.Interfaces;

public interface IBicicletaService
{
    public Bicicleta ObterBicicleta(int id);
}
