using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace bicicletario.WebAPI.Controllers;

public class TrancasController : ControllerBase
{
     private readonly ITrancaService _trancaService;

    public TrancasController(ITrancaService trancaService)
    {
        _trancaService = trancaService;
    }

    // GET: /tranca
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var trancas = await _trancaService.ObterTodasTrancas();
            var enumerable = trancas.ToList();
            if (!enumerable.Any())
            {
                return NotFound(new { mensagem = "Nenhuma tranca encontrada." });
            }

            return Ok(new { mensagem = "Trancas recuperadas com sucesso.", trancas = enumerable });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao recuperar trancas.", erro = ex.Message });
        }
    }

    // GET: /tranca/{idTranca}
    [HttpGet("{idTranca}")]
    public async Task<IActionResult> Get(int idTranca)
    {
        try
        {
            var tranca = await _trancaService.ObterTrancaPorId(idTranca);
            return Ok(new { mensagem = "Tranca Encontrada.", tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new { mensagem = ex.Message });
        }
    }

    // POST: /tranca
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NovaTrancaRequest novaTrancaRequest)
    {
        try
        {
            var tranca = await _trancaService.IncluirTranca(novaTrancaRequest);
            return CreatedAtAction(nameof(Create), new { id = tranca.Id }, tranca);
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new { mensagem = ex.Message });
        }
    }

    // PUT: /tranca/{idTranca}
    [HttpPut("{idTranca}")]
    public async Task<IActionResult> Update(int idTranca, [FromBody] Tranca trancaAtualizada)
    {
        try
        {
            var tranca = await _trancaService.AtualizarTranca(idTranca, trancaAtualizada);
            return Ok(new { mensagem = "Tranca atualizada com sucesso.", tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new { mensagem = ex.Message });
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new { mensagem = ex.Message });
        }
    }

    // DELETE: /tranca/{idTranca}
    [HttpDelete("{idTranca}")]
    public async Task<IActionResult> Delete(int idTranca)
    {
        try
        {
            var tranca = await _trancaService.RemoverTranca(idTranca);
            return Ok(new { mensagem = "Tranca excluída com sucesso.", tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new { mensagem = ex.Message });
        }
    }


    // PUT: /tranca/{idTranca}/integrar
    [HttpPut("{idTranca}/integrar")]
    public async Task<IActionResult> IntegrarNaRede(int idTranca)
    {
        try
        {
            var tranca = await _trancaService.IntegrarNaRede(idTranca);
            return Ok(new { mensagem = "Tranca integrada com sucesso.", tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new { mensagem = ex.Message });
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new { mensagem = ex.Message });
        }
    }

    // PUT: /tranca/{idTranca}/retirar
    [HttpPut("{idTranca}/retirar")]
    public async Task<IActionResult> RetirarDaRede(int idTranca, [FromBody] RetirarDaRedeRequest retirarTrancaRequest)
    {
        try
        {
            var tranca = await _trancaService.RetirarDaRede(idTranca, retirarTrancaRequest);
            return Ok(new { mensagem = "Tranca retirada com sucesso.", tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new { mensagem = ex.Message });
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new { mensagem = ex.Message });
        }
    }
    
    // PUT: /tranca/{idTranca}/status
    [HttpPut("{idTranca}/status/{acao}")]
    public async Task<IActionResult> AtualizarStatus(int idTranca, [FromRoute] AcaoEnum acao)
    {
        try
        {
            var tranca = await _trancaService.AtualizarStatus(idTranca, acao);
            return Ok(new { mensagem = "Tranca atualizada com sucesso.", tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new { mensagem = ex.Message });
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new { mensagem = ex.Message });
        }
    }

    // POST: /tranca/{idTranca}/trancar
    [HttpPost("{idTranca}/trancar")]
    public async Task<IActionResult> Trancar(int idTranca)
    {
        try
        {
            var tranca = await _trancaService.TrancarTranca(idTranca);
            return Ok(new { mensagem = "Ação bem sucedida", tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new { mensagem = ex.Message });
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new { mensagem = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(422, new { mensagem = "Tranca Ja se encontra trancada", erro = ex.Message });
        }
    }

    // POST: /tranca/{idTranca}/destrancar
    public async Task<IActionResult> DestrancarBicicleta(int idTranca)
    {
        try
        {
            var tranca = await _trancaService.DestrancarTranca(idTranca);
            return Ok(new { mensagem = "Ação bem sucedida", tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new { mensagem = ex.Message });
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new { mensagem = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(422, new { mensagem = "Tranca Ja se encontra destrancada", erro = ex.Message });
        }
    }
}
