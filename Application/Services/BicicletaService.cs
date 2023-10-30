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
        Task<Bicicleta> bicicleta = _bicicletaRepository.Get(id);

        if (bicicleta == null)
            throw new BicicletaNaoEncontradaException(id);

        return bicicleta;
    }
    
    public IEnumerable<Bicicleta> ObterTodasBicicletas()
    {
        IEnumerable<Bicicleta> bicicletas = _bicicletaRepository.GetAll();

        Bicicleta[] obterTodasBicicletas = bicicletas as Bicicleta[] ?? bicicletas.ToArray();
        if (bicicletas == null || !obterTodasBicicletas.Any())
            throw new BicicletaNaoEncontradaException();

        return obterTodasBicicletas;
    }
}
