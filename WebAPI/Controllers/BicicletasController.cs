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
    public IActionResult Get(int id)
    {
        try
        {
            var bicicleta = _bicicletaService.ObterBicicleta(id);

            return Ok(bicicleta);
        }
        catch (BicicletaNaoEncontradaException ex)
        {
            return NotFound(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            throw new ErroServidorInternoException(ex.Message);
        }
    }

    [HttpGet]
    public IEnumerable<Bicicleta> Get()
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
