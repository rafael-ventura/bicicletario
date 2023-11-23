using bicicletario.Application.Exceptions;
using bicicletario.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos.requests;
using bicicletario.Domain.dtos.responses;

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
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var totens = await _totemService.ObterTodosTotens();
            return Ok(new TotemResponse { Mensagem = "Totens encontrados.", Totens = totens });
        }
        catch (TotemNaoEncontradoException)
        {
            return NotFound(new TotemResponse { Mensagem = "Nenhum totem encontrado." });
        }
        catch (Exception)
        {
            return StatusCode(500, new TotemResponse { Mensagem = "Erro ao listar totens." });
        }
    }


    // POST: /totem
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NovoTotemRequest novoTotemRequest)
    {
        try
        {
            var totems = await _totemService.IncluirTotem(novoTotemRequest);
            return Ok(new TotemResponse { Mensagem = "Totem criado com sucesso.", Totem = totems });
        }
        catch (Exception)
        {
            return StatusCode(500, new TotemResponse { Mensagem = "Erro ao criar totem." });
        }
    }

    // PUT: /totem/{numero}
    [HttpPut("{numero}")]
    public async Task<IActionResult> Update(int idTotem, [FromBody] Totem totemAtualizado)
    {
        try
        {
            var totemEditado = await _totemService.EditarTotem(idTotem, totemAtualizado);
            return Ok(new TotemResponse { Mensagem = "Totem editado com sucesso.", Totem = totemEditado });
        }

        catch (TotemNaoEncontradoException)
        {
            return NotFound(new TotemResponse { Mensagem = "Totem não encontrado." });
        }
        catch (Exception)
        {
            return StatusCode(500, new TotemResponse { Mensagem = "Erro ao editar totem." });
        }
    }

    // DELETE: /totem/{numero}
    [HttpDelete("{numero}")]
    public async Task<IActionResult> Delete(int idTotem)
    {
        try
        {
            var totem = await _totemService.RemoverTotem(idTotem);
            return Ok(new TotemResponse { Mensagem = "Totem removido com sucesso.", Totem = totem });
        }
        catch (TotemNaoEncontradoException)
        {
            return NotFound(new TotemResponse { Mensagem = "Totem não encontrado." });
        }
        catch (Exception)
        {
            return StatusCode(500, new TotemResponse { Mensagem = "Erro ao remover totem." });
        }
    }

    // GET: /totem/{numero}/trancas
    [HttpGet("{numero}/trancas")]
    public async Task<IActionResult> GetTrancasDoTotem(int idTotem)
    {
        try
        {
            var trancas = await _totemService.ListarTrancasDoTotem(idTotem);
            return Ok(new TrancaResponse { Mensagem = "Trancas listadas com sucesso.", Trancas = trancas });
        }
        catch (TotemNaoEncontradoException)
        {
            return NotFound(new TrancaResponse { Mensagem = "Totem não encontrado." });
        }
        catch (Exception)
        {
            return StatusCode(500, new TrancaResponse { Mensagem = "Erro ao listar trancas do totem." });
        }
    }

    // GET: /totem/{numero}/bicicletas
    [HttpGet("{numero}/bicicletas")]
    public async Task<IActionResult> GetBicicletasDoTotem(int idTotem)
    {
        try
        {
            var bicicletas = await _totemService.ListarBicicletasDoTotem(idTotem);
            return Ok(new BicicletaResponse { Mensagem = "Bicicletas listadas com sucesso.", Bicicletas = bicicletas });
        }
        catch (TotemNaoEncontradoException)
        {
            return NotFound(new BicicletaResponse { Mensagem = "Totem não encontrado." });
        }
        catch (Exception)
        {
            return StatusCode(500, new BicicletaResponse { Mensagem = "Erro ao listar bicicletas do totem." });
        }
    }
}
