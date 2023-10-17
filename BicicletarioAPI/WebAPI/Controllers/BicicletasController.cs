using BicicletarioAPI.BicicletarioAPI.Application;
using Microsoft.AspNetCore.Mvc;

namespace BicicletarioAPI.BicicletarioAPI.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BicicletasController : ControllerBase
{
    private readonly BicicletaService _bicicletaService;

    public BicicletasController(BicicletaService bicicletaService)
    {
        _bicicletaService = bicicletaService;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var bicicleta = _bicicletaService.ObterBicicleta(id);
        return Ok(bicicleta);
    }
}
