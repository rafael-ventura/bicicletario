using bicicletario.Application.Exceptions;
using bicicletario.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;

namespace bicicletario.WebAPI.Controllers;

// TotemController.cs

[ApiController]
[Route("[controller]")]
public class TotemController : ControllerBase
{
    private readonly ITotemService _totemService;

    public TotemController(ITotemService totemService)
    {
        _totemService = totemService;
    }

    // GET: /totem
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var totens = await _totemService.ObterTodosTotens();
            if (!totens.Any())
            {
                return NotFound(new { mensagem = "Nenhum totem encontrado." });
            }

            return Ok(new { mensagem = "Totens recuperados com sucesso.", totens });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao recuperar totens.", erro = ex.Message });
        }
    }

    // POST: /totem
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NovoTotemRequest novoTotemRequest)
    {
        try
        {
            var totems = await _totemService.IncluirTotem(novoTotemRequest);
            return Ok(new { mensagem = "Totem criado com sucesso.", totem = totems });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao criar totem.", erro = ex.Message });
        }
    }

    // PUT: /totem/{numero}
    [HttpPut("{numero}")]
    public async Task<IActionResult> Update(int idTotem, [FromBody] Totem totemAtualizado)
    {
        try
        {
            var totemEditado = await _totemService.EditarTotem(idTotem, totemAtualizado);
            return Ok(new { mensagem = "Totem editado com sucesso.", totemEditado });
        }

        catch (TotemNaoEncontradoException)
        {
            return NotFound(new { mensagem = "Totem não encontrado." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao editar totem.", erro = ex.Message });
        }
    }

    // DELETE: /totem/{numero}
    [HttpDelete("{numero}")]
    public async Task<IActionResult> Delete(int idTotem)
    {
        try
        {
            await _totemService.RemoverTotem(idTotem);
            return Ok(new { mensagem = "Totem removido com sucesso." });
        }
        catch (TotemNaoEncontradoException)
        {
            return NotFound(new { mensagem = "Totem não encontrado." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao remover totem.", erro = ex.Message });
        }
    }

    // GET: /totem/{numero}/trancas
    [HttpGet("{numero}/trancas")]
    public async Task<IActionResult> GetTrancasDoTotem(int idTotem)
    {
        try
        {
            var trancas = await _totemService.ListarTrancasDoTotem(idTotem);
            return Ok(new { mensagem = "Trancas listadas com sucesso.", trancas });
        }
        catch (TotemNaoEncontradoException)
        {
            return NotFound(new { mensagem = "Totem não encontrado." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao listar trancas do totem.", erro = ex.Message });
        }
    }

    // GET: /totem/{numero}/bicicletas
    [HttpGet("{numero}/bicicletas")]
    public async Task<IActionResult> GetBicicletasDoTotem(int idTotem)
    {
        try
        {
            var bicicletas = await _totemService.ListarBicicletasDoTotem(idTotem);
            return Ok(new { mensagem = "Bicicletas listadas com sucesso.", bicicletas });
        }
        catch (TotemNaoEncontradoException)
        {
            return NotFound(new { mensagem = "Totem não encontrado." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao listar bicicletas do totem.", erro = ex.Message });
        }
    }
}
