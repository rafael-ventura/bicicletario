using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos.requests;
using bicicletario.Domain.dtos.responses;
using bicicletario.Domain.Models;
using bicicletario.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace bicicletario.Tests;

public class TrancasControllerTests
{
    private readonly Mock<ITrancaService> _trancaServiceMock;
    private readonly TrancaController _trancasController;

    public TrancasControllerTests()
    {
        _trancaServiceMock = new Mock<ITrancaService>();
        _trancasController = new TrancaController(_trancaServiceMock.Object);
    }

    [Fact]
    public async Task Get_RetornaOkComTrancas_QuandoTrancasExistem()
    {
        var trancasMockadas = new List<Tranca>
        {
            new Tranca { Id = 1, Numero = 1, Status = TrancaStatus.Livre },
            new Tranca { Id = 2, Numero = 2, Status = TrancaStatus.Ocupada }
        };

        _trancaServiceMock.Setup(s => s.ObterTodasTrancas()).ReturnsAsync(trancasMockadas);

        var resultado = await _trancasController.Get();

        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var retorno = Assert.IsType<TrancaResponse>(okResult.Value);
        Assert.Equal(trancasMockadas, retorno.Trancas!);
    }


    [Fact]
    public async Task Get_RetornaNotFound_QuandoNenhumaTrancaEncontrada()
    {
        _trancaServiceMock.Setup(s => s.ObterTodasTrancas()).ThrowsAsync(new TrancaNaoEncontradaException());

        var resultado = await _trancasController.Get();

        Assert.IsType<NotFoundObjectResult>(resultado); // Se espera um NotFoundObjectResult
    }


    [Fact]
    public async Task GetById_RetornaOkComTranca_QuandoTrancaExiste()
    {
        var trancaMockada = new Tranca { Id = 1, Numero = 1, Status = TrancaStatus.Livre };

        _trancaServiceMock.Setup(s => s.ObterTrancaPorId(1)).ReturnsAsync(trancaMockada);

        var resultado = await _trancasController.Get(1);

        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var retorno = Assert.IsType<TrancaResponse>(okResult.Value);
        Assert.Equal(trancaMockada, retorno.Tranca);
    }

    [Fact]
    public async Task GetById_RetornaNotFound_QuandoTrancaNaoExiste()
    {
        _trancaServiceMock.Setup(s => s.ObterTrancaPorId(1)).ThrowsAsync(new TrancaNaoEncontradaException(1));

        var resultado = await _trancasController.Get(1);

        Assert.IsType<NotFoundObjectResult>(resultado);
    }

    [Fact]
    public async Task Create_RetornaCreatedAtComNovaTranca_QuandoCriada()
    {
        var novaTrancaRequest = new NovaTrancaRequest
            { Numero = 1, Localizacao = "Localização", Modelo = "Modelo", AnoDeFabricacao = "2021" };
        var trancaCriada = new Tranca
        {
            Id = 1,
            Numero = 1,
            Localizacao = "Localização",
            Modelo = "Modelo",
            AnoDeFabricacao = "2021",
            Status = TrancaStatus.Livre
        };
        _trancaServiceMock.Setup(s => s.IncluirTranca(novaTrancaRequest)).ReturnsAsync(trancaCriada);

        var resultado = await _trancasController.Create(novaTrancaRequest);

        var createdAtResult = Assert.IsType<CreatedAtActionResult>(resultado);
        var retorno = Assert.IsType<TrancaResponse>(createdAtResult.Value);
        Assert.Equal(trancaCriada, retorno.Tranca);
    }


    [Fact]
    public async Task Create_RetornaUnprocessableEntity_QuandoDadosInvalidos()
    {
        var novaTranca = new NovaTrancaRequest
        {
            Numero = 1,
            Localizacao = "Localização",
            Modelo = "Modelo",
            AnoDeFabricacao = "2021"
        };

        _trancaServiceMock.Setup(s => s.IncluirTranca(novaTranca))
            .ThrowsAsync(new DadosInvalidosException("Dados inválidos."));

        var resultado = await _trancasController.Create(novaTranca);

        var unprocessableEntityResult = Assert.IsType<UnprocessableEntityObjectResult>(resultado);
        var retorno = Assert.IsType<TrancaResponse>(unprocessableEntityResult.Value);
        Assert.Equal("Dados inválidos.", retorno.Mensagem);
    }

    [Fact]
    public async Task Update_RetornaOkComTrancaAtualizada_QuandoSucesso()
    {
        var trancaAtualizada = new Tranca
        {
            Id = 1,
            Numero = 1,
            Localizacao = "Localização",
            Modelo = "Modelo",
            AnoDeFabricacao = "2021",
            Status = TrancaStatus.Livre
        };

        _trancaServiceMock.Setup(s => s.AtualizarTranca(1, trancaAtualizada)).ReturnsAsync(trancaAtualizada);

        var resultado = await _trancasController.Update(1, trancaAtualizada);

        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var retorno = Assert.IsType<TrancaResponse>(okResult.Value);
        Assert.Equal(trancaAtualizada, retorno.Tranca);
    }

    [Fact]
    public async Task Update_RetornaNotFound_QuandoTrancaNaoExiste()
    {
        var trancaAtualizada = new Tranca
        {
            Id = 1,
            Numero = 1,
            Localizacao = "Localização",
            Modelo = "Modelo",
            AnoDeFabricacao = "2021",
            Status = TrancaStatus.Livre
        };

        _trancaServiceMock.Setup(s => s.AtualizarTranca(1, trancaAtualizada))
            .ThrowsAsync(new TrancaNaoEncontradaException(1));

        var resultado = await _trancasController.Update(1, trancaAtualizada);

        Assert.IsType<NotFoundObjectResult>(resultado);
    }

    [Fact]
    public async Task Update_RetornaUnprocessableEntity_QuandoDadosInvalidos()
    {
        var trancaAtualizada = new Tranca
        {
            Id = 1,
            Numero = 1,
            Localizacao = "Localização",
            Modelo = "Modelo",
            AnoDeFabricacao = "2021",
            Status = TrancaStatus.Livre
        };

        _trancaServiceMock.Setup(s => s.AtualizarTranca(1, trancaAtualizada))
            .ThrowsAsync(new DadosInvalidosException("Dados inválidos."));

        var resultado = await _trancasController.Update(1, trancaAtualizada);

        var unprocessableEntityResult = Assert.IsType<UnprocessableEntityObjectResult>(resultado);
        var retorno = Assert.IsType<TrancaResponse>(unprocessableEntityResult.Value);
        Assert.Equal("Dados inválidos.", retorno.Mensagem);
    }

    [Fact]
    public async Task Delete_RetornaOk_QuandoTrancaExcluida()
    {
        _trancaServiceMock.Setup(s => s.RemoverTranca(1)).ReturnsAsync(new Tranca());

        var resultado = await _trancasController.Delete(1);

        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var retorno = Assert.IsType<TrancaResponse>(okResult.Value);
        Assert.Equal("Tranca excluída com sucesso.", retorno.Mensagem);
    }

    [Fact]
    public async Task Delete_RetornaNotFound_QuandoTrancaNaoExiste()
    {
        _trancaServiceMock.Setup(s => s.RemoverTranca(1)).ThrowsAsync(new TrancaNaoEncontradaException(1));

        var resultado = await _trancasController.Delete(1);

        Assert.IsType<NotFoundObjectResult>(resultado);
    }

    [Fact]
    public async Task IntegrarNaRede_RetornaOk_QuandoSucesso()
    {
        var trancaMockada = new Tranca { Id = 1, Status = TrancaStatus.Nova };
        _trancaServiceMock.Setup(s => s.IntegrarNaRede(1)).ReturnsAsync(trancaMockada);

        var resultado = await _trancasController.IntegrarNaRede(1);

        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var retorno = Assert.IsType<TrancaResponse>(okResult.Value);
        Assert.Equal("Tranca integrada com sucesso.", retorno.Mensagem);
        Assert.Equal(trancaMockada, retorno.Tranca);
    }

    [Fact]
    public async Task IntegrarNaRede_RetornaNotFound_QuandoTrancaNaoExiste()
    {
        _trancaServiceMock.Setup(s => s.IntegrarNaRede(1)).ThrowsAsync(new TrancaNaoEncontradaException(1));

        var resultado = await _trancasController.IntegrarNaRede(1);

        Assert.IsType<NotFoundObjectResult>(resultado);
    }

    [Fact]
    public async Task RetirarDaRede_RetornaOk_QuandoSucesso()
    {
        var retirarTrancaRequest = new RetirarDaRedeRequest { StatusAcaoReparador = "Manutenção" };
        var trancaMockada = new Tranca { Id = 1, Status = TrancaStatus.Livre };
        _trancaServiceMock.Setup(s => s.RetirarDaRede(1, retirarTrancaRequest)).ReturnsAsync(trancaMockada);

        var resultado = await _trancasController.RetirarDaRede(1, retirarTrancaRequest);

        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var retorno = Assert.IsType<TrancaResponse>(okResult.Value);
        Assert.Equal("Tranca retirada com sucesso.", retorno.Mensagem);
        Assert.Equal(trancaMockada, retorno.Tranca);
    }

    [Fact]
    public async Task RetirarDaRede_RetornaNotFound_QuandoTrancaNaoExiste()
    {
        var retirarTrancaRequest = new RetirarDaRedeRequest { StatusAcaoReparador = "Manutenção" };
        _trancaServiceMock.Setup(s => s.RetirarDaRede(1, retirarTrancaRequest))
            .ThrowsAsync(new TrancaNaoEncontradaException(1));

        var resultado = await _trancasController.RetirarDaRede(1, retirarTrancaRequest);

        Assert.IsType<NotFoundObjectResult>(resultado);
    }

    [Fact]
    public async Task AtualizarStatus_RetornaOk_QuandoSucesso()
    {
        var acao = AcaoEnum.Destrancar; // Exemplo de ação
        var trancaMockada = new Tranca { Id = 1, Status = TrancaStatus.Ocupada }; // Status depende da ação
        _trancaServiceMock.Setup(s => s.AtualizarStatus(1, acao)).ReturnsAsync(trancaMockada);

        var resultado = await _trancasController.AtualizarStatus(1, acao);

        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var retorno = Assert.IsType<TrancaResponse>(okResult.Value);
        Assert.Equal("Tranca atualizada com sucesso.", retorno.Mensagem);
        Assert.Equal(trancaMockada, retorno.Tranca);
    }

    [Fact]
    public async Task AtualizarStatus_RetornaNotFound_QuandoTrancaNaoExiste()
    {
        var acao = AcaoEnum.Destrancar; // Exemplo de ação
        _trancaServiceMock.Setup(s => s.AtualizarStatus(1, acao)).ThrowsAsync(new TrancaNaoEncontradaException(1));

        var resultado = await _trancasController.AtualizarStatus(1, acao);

        Assert.IsType<NotFoundObjectResult>(resultado);
    }

    [Fact]
    public async Task Trancar_RetornaOk_QuandoSucesso()
    {
        var trancaMockada = new Tranca { Id = 1, Status = TrancaStatus.Ocupada };
        _trancaServiceMock.Setup(s => s.TrancarTranca(1)).ReturnsAsync(trancaMockada);

        var resultado = await _trancasController.Trancar(1);

        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var retorno = Assert.IsType<TrancaResponse>(okResult.Value);
        Assert.Equal("Tranca trancada com sucesso.", retorno.Mensagem);
        Assert.Equal(trancaMockada, retorno.Tranca);
    }

    [Fact]
    public async Task Trancar_RetornaNotFound_QuandoTrancaNaoExiste()
    {
        _trancaServiceMock.Setup(s => s.TrancarTranca(1)).ThrowsAsync(new TrancaNaoEncontradaException(1));

        var resultado = await _trancasController.Trancar(1);

        Assert.IsType<NotFoundObjectResult>(resultado);
    }

    [Fact]
    public async Task DestrancarBicicleta_RetornaOk_QuandoSucesso()
    {
        var trancaMockada = new Tranca { Id = 1, Status = TrancaStatus.Livre };
        _trancaServiceMock.Setup(s => s.DestrancarTranca(1)).ReturnsAsync(trancaMockada);

        var resultado = await _trancasController.DestrancarBicicleta(1);

        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var trancaResponse = Assert.IsType<TrancaResponse>(okResult.Value);
        Assert.NotNull(trancaResponse.Tranca);
    }


    [Fact]
    public async Task DestrancarBicicleta_RetornaNotFound_QuandoTrancaNaoExiste()
    {
        _trancaServiceMock.Setup(s => s.DestrancarTranca(1)).ThrowsAsync(new TrancaNaoEncontradaException(1));

        var resultado = await _trancasController.DestrancarBicicleta(1);

        Assert.IsType<NotFoundObjectResult>(resultado);
    }
}