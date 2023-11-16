using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Domain.Interfaces;

public interface ITotemRepository
    
{
   public Task<IEnumerable<Totem>> ObterTodosTotens();
   
   public Task<Totem> ObterTotemPorId(int id);
   
   public Task<Totem> IncluirTotem(NovoTotemRequest novoNovoTotemRequest);
   
   public Task<Totem> EditarTotem(int id, Totem totemAtualizado);
   
   public Task<Totem> RemoverTotem(int id);
   
   public Task<IEnumerable<Tranca>> ListarTrancasDoTotem(int idTotem);
   
   public Task<IEnumerable<Bicicleta>> ListarBicicletasDoTotem(int idTotem);
   
   
   
}
