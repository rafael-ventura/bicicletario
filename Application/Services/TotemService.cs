using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Services;

public class TotemService
{
    
    private readonly ITotemRepository _totemRepository;
    
    public TotemService(ITotemRepository totemRepository)
    {
        _totemRepository = totemRepository;
    }


    public Task<Totem> CriarTotem(TotemRequest totem)
    {

        var totemCriado = _totemRepository.CriarTotem(totem);
    }
    
    public Task<Totem> EditarTotem(int idTotem, Totem totemAtualizado)
    {
        var totemEditado = _totemRepository.EditarTotem(idTotem, totemAtualizado);
    }
    
    public Task<Totem> RemoverTotem(int idTotem)
    {
        var totemRemovido = _totemRepository.RemoverTotem(idTotem);
    }
}
