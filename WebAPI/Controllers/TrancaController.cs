using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos.requests;
using bicicletario.Domain.dtos.responses;
using bicicletario.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace bicicletario.WebAPI.Controllers;

public class TrancaController : ControllerBase
{
     private readonly ITrancaService _trancaService;

    public TrancaController(ITrancaService trancaService)
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
                return NotFound(new TrancaResponse { Mensagem = "Nenhuma tranca encontrada." });
            }

            return Ok(new TrancaResponse { Mensagem = "Trancas encontradas.", Trancas = enumerable });
        }
        catch (Exception)
        {
            return NotFound(new TrancaResponse { Mensagem = "Erro ao listar trancas." });
        }
    }

    // GET: /tranca/{idTranca}
    [HttpGet("{idTranca}")]
    public async Task<IActionResult> Get(int idTranca)
    {
        try
        {
            var tranca = await _trancaService.ObterTrancaPorId(idTranca);
            return Ok(new TrancaResponse { Mensagem = "Tranca encontrada.", Tranca = tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new TrancaResponse { Mensagem = ex.Message });
        }
    }

    // POST: /tranca
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NovaTrancaRequest novaTrancaRequest)
    {
        try
        {
            var tranca = await _trancaService.IncluirTranca(novaTrancaRequest);
            return CreatedAtAction(nameof(Create), new TrancaResponse { Mensagem = "Tranca criada com sucesso.", Tranca = tranca });
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new TrancaResponse { Mensagem = ex.Message });
        }
    }

    // PUT: /tranca/{idTranca}
    [HttpPut("{idTranca}")]
    public async Task<IActionResult> Update(int idTranca, [FromBody] Tranca trancaAtualizada)
    {
        try
        {
            var tranca = await _trancaService.AtualizarTranca(idTranca, trancaAtualizada);
            return Ok(new TrancaResponse { Mensagem = "Tranca atualizada com sucesso.", Tranca = tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new TrancaResponse { Mensagem = ex.Message });
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new TrancaResponse { Mensagem = ex.Message });
        }
    }

    // DELETE: /tranca/{idTranca}
    [HttpDelete("{idTranca}")]
    public async Task<IActionResult> Delete(int idTranca)
    {
        try
        {
            var tranca = await _trancaService.RemoverTranca(idTranca);
            return Ok(new TrancaResponse { Mensagem = "Tranca excluída com sucesso.", Tranca = tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new TrancaResponse { Mensagem = ex.Message });
        }
    }


    // PUT: /tranca/{idTranca}/integrar
    [HttpPut("{idTranca}/integrar")]
    public async Task<IActionResult> IntegrarNaRede(int idTranca)
    {
        try
        {
            var tranca = await _trancaService.IntegrarNaRede(idTranca);
            return Ok(new TrancaResponse { Mensagem = "Tranca integrada com sucesso.", Tranca = tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new TrancaResponse { Mensagem = ex.Message });
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new TrancaResponse { Mensagem = ex.Message });
        }
    }

    // PUT: /tranca/{idTranca}/retirar
    [HttpPut("{idTranca}/retirar")]
    public async Task<IActionResult> RetirarDaRede(int idTranca, [FromBody] RetirarDaRedeRequest retirarTrancaRequest)
    {
        try
        {
            var tranca = await _trancaService.RetirarDaRede(idTranca, retirarTrancaRequest);
            return Ok(new TrancaResponse { Mensagem = "Tranca retirada com sucesso.", Tranca = tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new TrancaResponse { Mensagem = ex.Message });
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new TrancaResponse { Mensagem = ex.Message });
        }
    }
    
    // PUT: /tranca/{idTranca}/status
    [HttpPut("{idTranca}/status/{acao}")]
    public async Task<IActionResult> AtualizarStatus(int idTranca, [FromRoute] AcaoEnum acao)
    {
        try
        {
            var tranca = await _trancaService.AtualizarStatus(idTranca, acao);
            return Ok(new TrancaResponse { Mensagem = "Tranca atualizada com sucesso.", Tranca = tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new TrancaResponse { Mensagem = ex.Message });
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new TrancaResponse { Mensagem = ex.Message });
        }
    }

    // POST: /tranca/{idTranca}/trancar
    [HttpPost("{idTranca}/trancar")]
    public async Task<IActionResult> Trancar(int idTranca)
    {
        try
        {
            var tranca = await _trancaService.TrancarTranca(idTranca);
            return Ok(new TrancaResponse { Mensagem = "Tranca trancada com sucesso.", Tranca = tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new TrancaResponse { Mensagem = ex.Message });
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new TrancaResponse { Mensagem = ex.Message });
        }
    }

    // POST: /tranca/{idTranca}/destrancar
    public async Task<IActionResult> DestrancarBicicleta(int idTranca)
    {
        try
        {
            var tranca = await _trancaService.DestrancarTranca(idTranca);
            return Ok(new TrancaResponse { Mensagem = "Tranca destrancada com sucesso.", Tranca = tranca });
        }
        catch (TrancaNaoEncontradaException ex)
        {
            return NotFound(new TrancaResponse { Mensagem = ex.Message });
        }
        catch (DadosInvalidosException ex)
        {
            return UnprocessableEntity(new TrancaResponse { Mensagem = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(422, new TrancaResponse { Mensagem = ex.Message });
        }
    }
}
