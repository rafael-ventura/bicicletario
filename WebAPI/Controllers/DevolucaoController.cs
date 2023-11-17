using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using Microsoft.AspNetCore.Mvc;

namespace bicicletario.WebAPI.Controllers;

public class DevolucaoController : ControllerBase
{
    private readonly IDevolucaoService _devolucaoService;

    public DevolucaoController(IDevolucaoService devolucaoService)
    {
        _devolucaoService = devolucaoService;
    }


    // POST: /devolucao
    [HttpPost]
    public async Task<IActionResult> Devolver([FromBody] NovaDevolucaoRequest novaDevolucaoRequest)
    {
        // Verifica se a bici e o totem existem e se a bici estava alugada 

        if (novaDevolucaoRequest.IdBicicleta == 0 || novaDevolucaoRequest.IdTranca == 0)
        {
            throw new DadosInvalidosException();
        }

        try
        {
            var devolucao = await _devolucaoService.CriarDevolucao(novaDevolucaoRequest);
            return CreatedAtAction(nameof(Devolver), new { id = devolucao.BicicletaId }, devolucao);
        }
        catch (ApiException e)
        {
            throw new ApiException(e.Message, e.StatusCode);
        }
    }
}
