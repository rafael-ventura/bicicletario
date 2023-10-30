using BicicletarioAPI.Domain.Models;

namespace BicicletarioAPI.Domain.Interfaces;

public interface IBicicletaRepository
{
    public Task<Bicicleta> Get(int id);
    
    public IEnumerable<Bicicleta> GetAll();
}
