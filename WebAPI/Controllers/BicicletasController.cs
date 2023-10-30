using BicicletarioAPI.Application;
using BicicletarioAPI.Application.Interfaces;
using BicicletarioAPI.Application.Services;
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

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var bicicleta = _bicicletaService.ObterBicicleta(id);
        return Ok(bicicleta);
    }
}
