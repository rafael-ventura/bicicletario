using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bicicletario.WebAPI.Controllers;
public class CobrancaController : ControllerBase
{
    private readonly ICobrancaService _cobrancaService;

    public CobrancaController(ICobrancaService cobrancaService)
    {
        _cobrancaService = cobrancaService;
    }

    // POST: /cobranca
    [HttpPost]
    public async Task<IActionResult> Cobrar([FromBody] NovaCobrancaRequest novaCobrancaRequest)
    {
        // Verifica se o campo valor é nulo ou vazio    
        if (novaCobrancaRequest.Valor is 0 or < 0)
        {
            throw new CobrancaInvalidaException();
        }

        try
        {
            var cobranca = await _cobrancaService.CriarCobranca(novaCobrancaRequest);
            return CreatedAtAction(nameof(Cobrar), new { id = cobranca.Id }, cobranca);
        }
        catch (ApiException e)
        {
            throw new ApiException(e.Message, e.StatusCode);
        }
    }
    
    // GET: /cobranca/{id} 
    [HttpGet("{id}")]
    public async Task<IActionResult> ObterCobrancaPorId(int id)
    {
        try
        {
            var cobranca = await _cobrancaService.ObterCobrancaPorId(id);
            return Ok(cobranca);
        }
        catch (ApiException e)
        {
            throw new ApiException(e.Message, e.StatusCode);
        }
    }
}
