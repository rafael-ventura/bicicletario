using bicicletario.Application.Exceptions;
using bicicletario.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using bicicletario.Application.Interfaces;

namespace bicicletario.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TotemController : ControllerBase
{
    private readonly ITotemService _iTotemService;

    public TotemController(ITotemService iTotemService)
    {
        _iTotemService = iTotemService;
    }

    // Adicionando métodos baseados nos endpoints listados no JSON...

    // POST: /totem
    [HttpPost("totem")]
    public async Task<IActionResult> CriarTotem([FromBody] Totem novoTotem)
    {
        try
        {
            var totemCriado = await _iTotemService.CriarTotem(novoTotem);
            return CreatedAtAction(nameof(CriarTotem), new { id = totemCriado.Id }, totemCriado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Erro ao criar totem.", erro = ex.Message });
        }
    }

    // PUT: /totem/{idTotem}
    [HttpPut("totem/{idTotem}")]
    public async Task<IActionResult> EditarTotem(int idTotem, [FromBody] Totem totemAtualizado)
    {
        try
        {
            var totemEditado = await _iTotemService.EditarTotem(idTotem, totemAtualizado);
            return Ok(new { mensagem = "Totem editado com sucesso.", totemEditado });
        }
        catch (TotemNaoEncontradoException ex)
        {
            return NotFound(new { mensagem = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Erro ao editar totem.", erro = ex.Message });
        }
    }

    // DELETE: /totem/{idTotem}
    [HttpDelete("totem/{idTotem}")]
    public async Task<IActionResult> RemoverTotem(int idTotem)
    {
        try
        {
            await _iTotemService.RemoverTotem(idTotem);
            return Ok(new { mensagem = "Totem removido com sucesso." });
        }
        catch (TotemNaoEncontradoException ex)
        {
            return NotFound(new { mensagem = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Erro ao remover totem.", erro = ex.Message });
        }
    }

    // Os outros métodos seguiriam um padrão semelhante, implementando a lógica conforme as operações CRUD básicas
    // e as especificações do seu arquivo JSON para as entidades de 'Tranca', 'Bicicleta', etc.

    // Certifique-se de que a camada de serviço (IEquipamentoService) tem métodos correspondentes para realizar as operações.
    // E que as exceções são tratadas adequadamente.
}

