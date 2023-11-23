using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos.requests;
using bicicletario.Domain.dtos.responses;
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
            return Ok(new BicicletaResponse { Mensagem = "Bicicletas encontradas.", Bicicletas = bicicletas });
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound(new BicicletaResponse { Mensagem = "Nenhuma bicicleta encontrada." });
        }
    }


    // POST: api/bicicletas
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] NovaBicicletaRequest novaBicicleta)
    {
        try
        {
            var bicicletaCriada = await _bicicletaService.CriarBicicleta(novaBicicleta);
            return Ok(new BicicletaResponse
                { Mensagem = "Bicicleta criada com sucesso.", Bicicleta = bicicletaCriada });
        }
        catch (DadosInvalidosException)
        {
            return BadRequest(new BicicletaResponse { Mensagem = "Dados inválidos." });
        }
    }

    // GET: api/bicicletas/{idBicicleta}
    [HttpGet("{idBicicleta}")]
    public async Task<IActionResult> Get(int idBicicleta)
    {
        try
        {
            var bicicleta = await _bicicletaService.ObterBicicleta(idBicicleta);
            return Ok(new BicicletaResponse { Mensagem = "Bicicleta encontrada.", Bicicleta = bicicleta });
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound(new BicicletaResponse { Mensagem = "Bicicleta não encontrada." });
        }
    }

    // PUT: api/bicicletas/{idBicicleta}
    [HttpPut("{idBicicleta}")]
    public async Task<IActionResult> Update(int id, [FromBody] NovaBicicletaRequest bicicleta)
    {
        try
        {
            var bicicletaAtualizada = await _bicicletaService.AtualizarBicicleta(id, bicicleta);
            return Ok(new BicicletaResponse
                { Mensagem = "Bicicleta atualizada com sucesso.", Bicicleta = bicicletaAtualizada });
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound(new BicicletaResponse { Mensagem = "Bicicleta não encontrada." });
        }
    }

// DELETE: api/bicicletas/{idBicicleta}
    [HttpDelete("{idBicicleta}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var bicicletaRemovida = await _bicicletaService.RemoverBicicleta(id);
            if (bicicletaRemovida)
            {
                return Ok(new BicicletaResponse { Mensagem = "Bicicleta removida com sucesso." });
            }

            return BadRequest(new BicicletaResponse { Mensagem = "Erro ao remover bicicleta." });
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound(new BicicletaResponse { Mensagem = "Bicicleta não encontrada." });
        }
    }

    [HttpPost("integrarNaRede")]
    public async Task<IActionResult> IntegrarNaRede([FromBody] IntegrarNaRedeRequest bicicleta)
    {
        try
        {
            var bicicletaIntegrada = await _bicicletaService.IntegrarNaRede(bicicleta);
            return Ok(new BicicletaResponse
                { Mensagem = "Bicicleta integrada na rede com sucesso.", Bicicleta = bicicletaIntegrada });
        }
        catch (DadosInvalidosException)
        {
            return BadRequest(new BicicletaResponse { Mensagem = "Dados inválidos." });
        }
    }

    [HttpPost("retirarDaRede")]
    public async Task<IActionResult> RetirarDaRede([FromBody] RetirarDaRedeRequest request)
    {
        try
        {
            var bicicletaRemovida = await _bicicletaService.RetirarDaRede(request);
            return Ok(new BicicletaResponse
                { Mensagem = "Bicicleta retirada da rede com sucesso.", Bicicleta = bicicletaRemovida });
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound(new BicicletaResponse { Mensagem = "Bicicleta não encontrada." });
        }
        catch (FuncionarioNaoAutorizadoException)
        {
            return BadRequest(new BicicletaResponse { Mensagem = "Funcionário não autorizado." });
        }
    }

    [HttpPut("{idBicicleta}/status/{acao}")]
    public async Task<IActionResult> AtualizarStatus(int idBicicleta, [FromRoute] BicicletaStatus acao)
    {
        try
        {
            var bicicletaAtualizada = await _bicicletaService.AtualizarStatus(idBicicleta, acao);
            return Ok(new BicicletaResponse
                { Mensagem = "Status da bicicleta atualizado com sucesso.", Bicicleta = bicicletaAtualizada });
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound(new BicicletaResponse { Mensagem = "Bicicleta não encontrada." });
        }
    }

    [HttpGet("numero/{numero}")]
    public async Task<IActionResult> ObterBicicletaPorNumero(int numero)
    {
        try
        {
            var bicicleta = await _bicicletaService.ObterBicicletaPorNumero(numero);
            return Ok(new BicicletaResponse { Mensagem = "Bicicleta encontrada.", Bicicleta = bicicleta });
        }
        catch (BicicletaNaoEncontradaException)
        {
            return NotFound(new BicicletaResponse { Mensagem = "Bicicleta não encontrada." });
        }
    }
}
