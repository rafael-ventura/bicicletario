using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos.requests;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Services;

public class TotemService : ITotemService
{
    private readonly ITotemRepository _totemRepository;

    public TotemService(ITotemRepository totemRepository)
    {
        _totemRepository = totemRepository;
    }

    public Task<List<Totem>> ObterTodosTotens()
    {
        var totens = _totemRepository.ObterTodosTotens();

        if (totens == null || !totens.Result.Any())
            throw new TotemNaoEncontradoException();

        return totens;
    }

    public Task<Totem> ObterTotem(int id)
    {
        var totem = _totemRepository.ObterTotemPorId(id);

        if (totem == null)
            throw new TotemNaoEncontradoException(id);

        return totem;
    }

    public Task<Totem> IncluirTotem(NovoTotemRequest novoNovoTotemRequest)
    {
        var totemCriado = _totemRepository.IncluirTotem(novoNovoTotemRequest);

        return totemCriado;
    }

    public Task<Totem> EditarTotem(int id, Totem totemAtualizado)
    {
        var totemEditado = _totemRepository.EditarTotem(id, totemAtualizado);

        return totemEditado;
    }

    public Task<Totem> RemoverTotem(int id)
    {
        var totemRemovido = _totemRepository.RemoverTotem(id);

        return totemRemovido;
    }


    public Task<List<Tranca>> ListarTrancasDoTotem(int idTotem)
    {
        var trancas = _totemRepository.ListarTrancasDoTotem(idTotem);

        if (trancas == null || !trancas.Result.Any())
            throw new TrancaNaoEncontradaException();

        return trancas;
    }

    public Task<List<Bicicleta>> ListarBicicletasDoTotem(int idTotem)
    {
        var bicicletas = _totemRepository.ListarBicicletasDoTotem(idTotem);

        if (bicicletas == null || !bicicletas.Result.Any())
            throw new BicicletaNaoEncontradaException();

        return bicicletas;
    }
}
