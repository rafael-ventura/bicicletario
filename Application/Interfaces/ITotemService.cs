using bicicletario.Domain.dtos.requests;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Interfaces;

public interface ITotemService
{
    public Task<List<Totem>> ObterTodosTotens();

    public Task<Totem> IncluirTotem(NovoTotemRequest novoNovoTotemRequest);

    public Task<Totem> EditarTotem(int id, Totem totemAtualizado);

    public Task<Totem> RemoverTotem(int id);

    public Task<List<Tranca>> ListarTrancasDoTotem(int idTotem);

    public Task<List<Bicicleta>> ListarBicicletasDoTotem(int idTotem);

    public Task<Totem> ObterTotem(int id);
}
