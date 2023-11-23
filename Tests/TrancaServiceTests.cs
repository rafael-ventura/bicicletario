using bicicletario.Application.Services;
using bicicletario.Domain.dtos.requests;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;
using Moq;

namespace bicicletario.Tests;

public class TrancaServiceTests
{
    private readonly Mock<ITrancaRepository> _mockTrancaRepository = new();

    [Fact]
    public async Task DeveRetornarTrancaPorId()
    {
        // Arrange
        var tranca = new Tranca
        {
            Id = 1, Modelo = "Tranca 1", Numero = 1, Status = TrancaStatus.Nova, Localizacao = "Local 1",
            BicicletaId = 1, AnoDeFabricacao = "2021"
        };
        _mockTrancaRepository.Setup(x => x.Get(1)).ReturnsAsync(tranca);

        var trancaService = new TrancaService(_mockTrancaRepository.Object);

        // Act
        var result = await trancaService.ObterTrancaPorId(1);

        // Assert
        Assert.Equal(tranca, result);
    }

    [Fact]
    public async Task DeveRetornarTodasTrancas()
    {
        // Arrange
        var tranca = new Tranca
        {
            Id = 1, Modelo = "Tranca 1", Numero = 1, Status = TrancaStatus.Nova, Localizacao = "Local 1",
            BicicletaId = 1, AnoDeFabricacao = "2021"
        };
        var tranca2 = new Tranca
        {
            Id = 2, Modelo = "Tranca 2", Numero = 2, Status = TrancaStatus.Nova, Localizacao = "Local 2",
            BicicletaId = 2, AnoDeFabricacao = "2021"
        };
        var tranca3 = new Tranca
        {
            Id = 3, Modelo = "Tranca 3", Numero = 3, Status = TrancaStatus.Nova, Localizacao = "Local 3",
            BicicletaId = 3, AnoDeFabricacao = "2021"
        };


        var trancas = new List<Tranca> { tranca, tranca2, tranca3 };

        _mockTrancaRepository.Setup(x => x.GetAll()).ReturnsAsync(trancas);

        var trancaService = new TrancaService(_mockTrancaRepository.Object);

        // Act
        var result = await trancaService.ObterTodasTrancas();

        // Assert
        Assert.Equal(trancas, result);
    }

    [Fact]
    public async Task DeveCriarTranca()
    {
        // Arrange
        var tranca = new Tranca
        {
            Id = 1, Modelo = "Tranca 1", Numero = 1, Status = TrancaStatus.Nova, Localizacao = "Local 1",
            BicicletaId = 1, AnoDeFabricacao = "2021"
        };
        var trancaRequest = new NovaTrancaRequest
        {
            Modelo = "Tranca 1", Numero = 1, Status = TrancaStatus.Nova, Localizacao = "Local 1",
            AnoDeFabricacao = "2021"
        };

        _mockTrancaRepository.Setup(x => x.Create(trancaRequest)).ReturnsAsync(tranca);

        var trancaService = new TrancaService(_mockTrancaRepository.Object);

        // Act
        var result = await trancaService.IncluirTranca(trancaRequest);

        // Assert
        Assert.Equal(tranca, result);
    }

    [Fact]
    public async Task DeveAtualizarTranca()
    {
        // Arrange
        var tranca = new Tranca
        {
            Id = 1, Modelo = "Tranca 1", Numero = 1, Status = TrancaStatus.Nova, Localizacao = "Local 1",
            BicicletaId = 1, AnoDeFabricacao = "2021"
        };
        var trancaAtualizada = new Tranca
        {
            Id = 1, Modelo = "Tranca 1", Numero = 1, Status = TrancaStatus.Nova, Localizacao = "Local 1",
            BicicletaId = 1, AnoDeFabricacao = "2021"
        };

        _mockTrancaRepository.Setup(x => x.Update(1, trancaAtualizada)).ReturnsAsync(tranca);

        var trancaService = new TrancaService(_mockTrancaRepository.Object);

        // Act
        var result = await trancaService.AtualizarTranca(1, trancaAtualizada);

        // Assert
        Assert.Equal(tranca, result);
    }

    [Fact]
    public async Task DeveRemoverTranca()
    {
        // Arrange
        var tranca = new Tranca
        {
            Id = 1, Modelo = "Tranca 1", Numero = 1, Status = TrancaStatus.Nova, Localizacao = "Local 1",
            BicicletaId = 1, AnoDeFabricacao = "2021"
        };

        _mockTrancaRepository.Setup(x => x.Delete(1)).ReturnsAsync(tranca);

        var trancaService = new TrancaService(_mockTrancaRepository.Object);

        // Act
        var result = await trancaService.RemoverTranca(1);

        // Assert
        Assert.Equal(tranca, result);
    }

    [Fact]
    public async Task DeveIntegrarTrancaNaRede()
    {
        // Arrange
        var tranca = new Tranca
        {
            Id = 1, Modelo = "Tranca 1", Numero = 1, Status = TrancaStatus.Nova, Localizacao = "Local 1",
            BicicletaId = 1, AnoDeFabricacao = "2021"
        };

        _mockTrancaRepository.Setup(x => x.IntegrarNaRede(1)).ReturnsAsync(tranca);

        var trancaService = new TrancaService(_mockTrancaRepository.Object);

        // Act
        var result = await trancaService.IntegrarNaRede(1);

        // Assert
        Assert.Equal(tranca, result);
    }

    [Fact]
    public async Task DeveRetirarTrancaDaRede()
    {
        // Arrange
        var tranca = new Tranca
        {
            Id = 1, Modelo = "Tranca 1", Numero = 1, Status = TrancaStatus.Nova, Localizacao = "Local 1",
            BicicletaId = 1, AnoDeFabricacao = "2021"
        };
        var retiradaTrancaRequest = new RetirarDaRedeRequest
        {
            IdBicicleta = 1, IdTranca = 1, IdFuncionario = 1, StatusAcaoReparador = "Reparar"
        };

        _mockTrancaRepository.Setup(x => x.RetirarDaRede(1, retiradaTrancaRequest)).ReturnsAsync(tranca);

        var trancaService = new TrancaService(_mockTrancaRepository.Object);

        // Act
        var result = await trancaService.RetirarDaRede(1, retiradaTrancaRequest);

        // Assert
        Assert.Equal(tranca, result);
    }

    [Fact]
    public async Task DeveAtualizarStatusDaTranca()
    {
        // Arrange
        var tranca = new Tranca
        {
            Id = 1, Modelo = "Tranca 1", Numero = 1, Status = TrancaStatus.Nova, Localizacao = "Local 1",
            BicicletaId = 1, AnoDeFabricacao = "2021"
        };

        _mockTrancaRepository.Setup(x => x.AtualizarStatus(1, AcaoEnum.Destrancar)).ReturnsAsync(tranca);

        var trancaService = new TrancaService(_mockTrancaRepository.Object);

        // Act
        var result = await trancaService.AtualizarStatus(1, AcaoEnum.Destrancar);

        // Assert
        Assert.Equal(tranca, result);
    }

    [Fact]
    public async Task DeveTrancarTranca()
    {
        // Arrange
        var tranca = new Tranca
        {
            Id = 1, Modelo = "Tranca 1", Numero = 1, Status = TrancaStatus.Ocupada, Localizacao = "Local 1",
            BicicletaId = 1, AnoDeFabricacao = "2021"
        };

        _mockTrancaRepository.Setup(x => x.TrancarTranca(1)).ReturnsAsync(tranca);

        var trancaService = new TrancaService(_mockTrancaRepository.Object);

        // Act
        var result = await trancaService.TrancarTranca(1);

        // Assert
        Assert.Equal(tranca, result);
    }

    [Fact]
    public async Task DeveDestrancarTranca()
    {
        // Arrange
        var tranca = new Tranca
        {
            Id = 1, Modelo = "Tranca 1", Numero = 1, Status = TrancaStatus.Livre, Localizacao = "Local 1",
            BicicletaId = 1, AnoDeFabricacao = "2021"
        };

        _mockTrancaRepository.Setup(x => x.DestrancarTranca(1)).ReturnsAsync(tranca);

        var trancaService = new TrancaService(_mockTrancaRepository.Object);

        // Act
        var result = await trancaService.DestrancarTranca(1);

        // Assert
        Assert.Equal(tranca, result);
    }
}
