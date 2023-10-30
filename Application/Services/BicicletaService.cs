// ReSharper disable once RedundantUsingDirective

using BicicletarioAPI.Application.Exceptions;
using BicicletarioAPI.Application.Interfaces;
using BicicletarioAPI.Domain;
using BicicletarioAPI.Domain.Interfaces;
using BicicletarioAPI.Domain.Models;

namespace BicicletarioAPI.Application.Services;

public class BicicletaService : IBicicletaService
{
    private readonly IBicicletaRepository _bicicletaRepository;

    public BicicletaService(IBicicletaRepository bicicletaRepository)
    {
        _bicicletaRepository = bicicletaRepository;
    }

    public Task<Bicicleta> ObterBicicleta(int id)
    {
        var bicicleta = _bicicletaRepository.Get(id);

        if (bicicleta == null)
            throw new BicicletaNaoEncontradaException(id);

        return bicicleta;
    }
    
    public Task<IEnumerable<Bicicleta>> ObterTodasBicicletas()
    {
        var bicicletas = _bicicletaRepository.GetAll();

        var obterTodasBicicletas = bicicletas as Bicicleta[] ?? bicicletas.ToArray();
        if (bicicletas == null || !obterTodasBicicletas.Any())
            throw new BicicletaNaoEncontradaException();

        return Task.FromResult<IEnumerable<Bicicleta>>(obterTodasBicicletas);
    }
}
