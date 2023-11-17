using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using Microsoft.AspNetCore.Mvc;

namespace bicicletario.WebAPI.Controllers;

public class AluguelController : ControllerBase
{
    private readonly IAluguelService _aluguelService;

    public AluguelController(IAluguelService aluguelService)
    {
        _aluguelService = aluguelService;
    }

    //
    // POST: /aluguel
    [HttpPost]
    public async Task<IActionResult> Aluguel([FromBody] NovoAluguelRequest novoAluguelRequest)
    {
        try
        {
            var aluguel = await _aluguelService.CriarAluguel(novoAluguelRequest);
            return CreatedAtAction(nameof(Aluguel), new { id = aluguel.BicicletaId }, aluguel);
        }
        catch (ApiException e)
        {
            throw new ApiException(e.Message, e.StatusCode);
        }
    }
}
