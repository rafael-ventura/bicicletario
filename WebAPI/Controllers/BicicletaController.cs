using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace bicicletario.WebAPI.Controllers;

// /bicicletas
[ApiController]
[Route("[controller]")]
public class BicicletaController : ControllerBase
{
    private readonly IBicicletaService _bicicletaService;

    public BicicletaController(IBicicletaService bicicletaService)
    {
        _bicicletaService = bicicletaService;
    }


    // GET: api/bicicletas
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var bicicletas = await _bicicletaService.ObterTodasBicicletas();
            return Ok(new { mensagem = "Bicicletas encontradas.", bicicletas });
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound(new { mensagem = "Nenhuma bicicleta encontrada." });
        }
    }

    // POST: api/bicicletas
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] NovaBicicletaRequest novaBicicleta)
    {
        try
        {
            var bicicletaCriada = await _bicicletaService.CriarBicicleta(novaBicicleta);
            return CreatedAtAction(nameof(GetAll), new { id = bicicletaCriada.Id },
                new { mensagem = "Dados cadastrados.", bicicletaCriada });
        }
        catch (DadosInvalidosException ex)
        {
            return StatusCode(ex.StatusCode, new { mensagem = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao cadastrar bicicleta.", erro = ex.Message });
        }
    }

    // GET: api/bicicletas/{idBicicleta}
    [HttpGet("{idBicicleta}")]
    public async Task<IActionResult> GetAll(int idBicicleta)
    {
        try
        {
            var bicicleta = await _bicicletaService.ObterBicicleta(idBicicleta);
            return Ok(new { mensagem = "Bicicleta encontrada.", bicicleta });
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound();
        }
    }

    // PUT: api/bicicletas/{idBicicleta}
    [HttpPut("{idBicicleta}")]
    public async Task<IActionResult> Update(int id, [FromBody] NovaBicicletaRequest bicicleta)
    {
        try
        {
            var bicicletaAtualizada = await _bicicletaService.AtualizarBicicleta(id, bicicleta);
            return Ok(new { mensagem = "Bicicleta atualizada com sucesso.", bicicletaAtualizada });
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound(new { mensagem = "Bicicleta não encontrada." });
        }
    }

// DELETE: api/bicicletas/{idBicicleta}
    [HttpDelete("{idBicicleta}")]
    public Task<IActionResult> Delete(int id)
    {
        try
        {
            var sucesso = _bicicletaService.RemoverBicicleta(id);
            if (sucesso)
            {
                return Task.FromResult<IActionResult>(Ok(new { mensagem = "Bicicleta removida com sucesso." }));
            }
            else
            {
                return Task.FromResult<IActionResult>(NotFound(new
                    { mensagem = "Bicicleta não encontrada para remoção." }));
            }
        }
        catch (Exception ex)
        {
            return Task.FromResult<IActionResult>(BadRequest(new
                { mensagem = "Erro ao remover bicicleta.", erro = ex.Message }));
        }
    }

    [HttpPost("integrarNaRede")]
    public async Task<IActionResult> IntegrarNaRede([FromBody] IntegrarNaRedeRequest bicicleta)
    {
        try
        {
            var bicicletaIntegrada = await _bicicletaService.IntegrarNaRede(bicicleta);
            return Ok(new { mensagem = "Dados cadastrados.", bicicletaIntegrada });
        }
        catch (DadosInvalidosException)
        {
            return BadRequest(new { mensagem = "Dados inválidos." });
        }
    }

    [HttpPost("retirarDaRede")]
    public async Task<IActionResult> RetirarDaRede([FromBody] RetirarDaRedeRequest request)
    {
        try
        {
            var bicicletaRemovida = await _bicicletaService.RetirarDaRede(request);
            return Ok(new { mensagem = "Bicicleta retirada da rede com sucesso.", bicicletaRemovida });
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound(new { mensagem = "Bicicleta não encontrada." });
        }
        catch (FuncionarioNaoAutorizadoException)
        {
            return BadRequest(new { mensagem = "Funcionário não autorizado." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao retirar a bicicleta da rede.", erro = ex.Message });
        }
    }

    [HttpPut("{idBicicleta}/status/{acao}")]
    public async Task<IActionResult> AtualizarStatus(int idBicicleta, [FromRoute] BicicletaStatus acao)
    {
        try
        {
            var bicicletaAtualizada = await _bicicletaService.AtualizarStatus(idBicicleta, acao);
            return Ok(new { mensagem = "Status da bicicleta atualizado com sucesso.", bicicletaAtualizada });
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound(new { mensagem = "Bicicleta não encontrada." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao atualizar o status da bicicleta.", erro = ex.Message });
        }
    }

    [HttpGet("numero/{numero}")]
    public async Task<IActionResult> ObterBicicletaPorNumero(int numero)
    {
        try
        {
            var bicicleta = await _bicicletaService.ObterBicicletaPorNumero(numero);
            return Ok(new { mensagem = "Bicicleta encontrada.", bicicleta });
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound(new { mensagem = "Bicicleta não encontrada." });
        }
    }
}
