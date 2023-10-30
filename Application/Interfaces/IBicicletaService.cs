using BicicletarioAPI.Domain;
using BicicletarioAPI.Domain.Models;

namespace BicicletarioAPI.Application.Interfaces;

public interface IBicicletaService
{
    public Task<Bicicleta> ObterBicicleta(int id);

    public Task<IEnumerable<Bicicleta>> ObterTodasBicicletas();
}
