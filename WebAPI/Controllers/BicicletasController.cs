using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace bicicletario.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BicicletasController : ControllerBase
{
    private readonly IBicicletaService _bicicletaService;

    public BicicletasController(IBicicletaService bicicletaService)
    {
        _bicicletaService = bicicletaService;
    }


    // GET: api/bicicletas
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var bicicletas = await _bicicletaService.ObterTodasBicicletas();
            if (bicicletas.Any())
            {
                return Ok(new { mensagem = "Bicicletas recuperadas com sucesso.", bicicletas });
            }
            else
            {
                return NotFound(new { mensagem = "Nenhuma bicicleta encontrada." });
            }
        }
        catch (Exception ex)
        {
            // Log the exception here
            return StatusCode(500, new { mensagem = "Erro ao recuperar bicicletas.", erro = ex.Message });
        }
    }

    // POST: api/bicicletas
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Bicicleta novaBicicleta)
    {
        try
        {
            var bicicletaCriada = await _bicicletaService.CriarBicicleta(novaBicicleta);
            return CreatedAtAction(nameof(Get), new { id = bicicletaCriada.Id },
                new { mensagem = "Bicicleta criada com sucesso.", bicicletaCriada });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Erro ao criar bicicleta.", erro = ex.Message });
        }
    }

    // GET: api/bicicletas/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var bicicleta = await _bicicletaService.ObterBicicleta(id);
            return Ok(bicicleta);
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound();
        }
    }

    // PUT: api/bicicletas/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBicicleta(int id, [FromBody] Bicicleta bicicleta)
    {
        try
        {
            var bicicletaAtualizada = await _bicicletaService.AtualizarBicicleta(id, bicicleta);
            if (bicicletaAtualizada != null)
            {
                return Ok(new { mensagem = "Bicicleta atualizada com sucesso.", bicicletaAtualizada });
            }
            else
            {
                return NotFound(new { mensagem = new BicicletaNaoEncontradaException() });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Erro ao atualizar bicicleta.", erro = ex.Message });
        }
    }

// DELETE: api/bicicletas/{id}
    [HttpDelete("{id}")]
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
    public async Task<IActionResult> IntegrarNaRede([FromBody] Bicicleta bicicleta)
    {
        try
        {
            var bicicletaCriada = await _bicicletaService.CriarBicicleta(bicicleta);
            return CreatedAtAction(nameof(Get), new { id = bicicletaCriada.Id }, bicicletaCriada);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPost("retirarDaRede")]
    public async Task<IActionResult> RetirarDaRede([FromBody] RetirarDaRedeRequest request)
    {
        try
        {
            var bicicletaRemovida = await _bicicletaService.RetirarDaRede(
                request.IdTranca,
                request.IdBicicleta,
                request.IdFuncionario,
                request.StatusAcaoReparador
            );
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
}
