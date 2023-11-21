using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Domain.Interfaces;

public interface ITotemRepository
    
{
   public Task<List<Totem>> ObterTodosTotens();
   
   public Task<Totem> ObterTotemPorId(int id);
   
   public  Task<Totem> IncluirTotem(NovoTotemRequest novoTotemRequest);
   
   public Task<Totem> EditarTotem(int id, Totem totemAtualizado);
   
   public Task<Totem> RemoverTotem(int id);
   
   public Task<List<Tranca>> ListarTrancasDoTotem(int idTotem);
   
   public Task<List<Bicicleta>> ListarBicicletasDoTotem(int idTotem);
   
   
   
}
