using BicicletarioAPI.Application.Exceptions;
using BicicletarioAPI.Application.Interfaces;
using BicicletarioAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BicicletarioAPI.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BicicletasController : ControllerBase
{
    private readonly IBicicletaService _bicicletaService;

    public BicicletasController(IBicicletaService bicicletaService)
    {
        _bicicletaService = bicicletaService;
    }

    [HttpGet("{id}")]
    public Task<Bicicleta> Get(int id)
    {
        try
        {
            var bicicleta = _bicicletaService.ObterBicicleta(id);

            return bicicleta;
        }
        catch (BicicletaNaoEncontradaException)
        {
            throw new BicicletaNaoEncontradaException(id);
        }
        catch (Exception ex)
        {
            throw new ErroServidorInternoException(ex.Message);
        }
    }

    [HttpGet]
    public Task<IEnumerable<Bicicleta>> Get()
    {
        try
        {
            return _bicicletaService.ObterTodasBicicletas();
        }
        catch (Exception ex)
        {
            throw new ErroServidorInternoException(ex.Message);
        }
    }
}
