using bicicletario.Application.Services;
using bicicletario.Domain.dtos.requests;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;
using Moq;

namespace bicicletario.Tests;

public class BicicletaServiceTests
{
    private readonly Mock<IBicicletaRepository> _bicicletaRepositoryMock = new();

    [Fact]
    public async Task DeveRetornarBicicletaPorId()
    {
        // Arrange
        var bicicleta = new Bicicleta(1, "Caloi", "Caloi 10", "Azul", 1, BicicletaStatus.Disponivel);

        _bicicletaRepositoryMock.Setup(x => x.Get(1)).ReturnsAsync(bicicleta);

        var bicicletaService = new BicicletaService(_bicicletaRepositoryMock.Object);

        // Act
        var result = await bicicletaService.ObterBicicleta(1);

        // Assert
        Assert.Equal(bicicleta, result);
    }

    [Fact]
    public async Task DeveRetornarTodasBicicletas()
    {
        // Arrange
        var bicicleta = new Bicicleta(1, "Caloi", "Caloi 10", "Azul", 1, BicicletaStatus.Disponivel);
        var bicicleta2 = new Bicicleta(2, "Caloi", "Caloi 10", "Azul", 1, BicicletaStatus.Disponivel);
        var bicicleta3 = new Bicicleta(3, "Caloi", "Caloi 10", "Azul", 1, BicicletaStatus.Disponivel);

        var bicicletas = new List<Bicicleta> { bicicleta, bicicleta2, bicicleta3 };

        _bicicletaRepositoryMock.Setup(x => x.GetAll()).Returns(bicicletas);

        var bicicletaService = new BicicletaService(_bicicletaRepositoryMock.Object);

        // Act
        var result = await bicicletaService.ObterTodasBicicletas();

        // Assert
        Assert.Equal(bicicletas, result);
    }

    [Fact]
    public async Task DeveCriarBicicleta()
    {
        // Arrange
        var bicicleta = new Bicicleta(1, "Caloi", "Caloi 10", "Azul", 1, BicicletaStatus.Disponivel);
        var bicicletaRequest = new NovaBicicletaRequest
        {
            Marca = "Caloi", Modelo = "Caloi 10", Ano = "Azul", Numero = 1, Status = BicicletaStatus.Disponivel
        };

        _bicicletaRepositoryMock.Setup(x => x.Create(bicicletaRequest)).ReturnsAsync(bicicleta);

        var bicicletaService = new BicicletaService(_bicicletaRepositoryMock.Object);

        // Act
        var result = await bicicletaService.CriarBicicleta(bicicletaRequest);

        // Assert
        Assert.Equal(bicicleta, result);
    }

    [Fact]
    public async Task DeveIntegrarBicicletaNaRede()
    {
        // Arrange
        var bicicleta = new Bicicleta(1, "Caloi", "Caloi 10", "Azul", 1, BicicletaStatus.Disponivel);
        var bicicletaRequest = new IntegrarNaRedeRequest
        {
            IdBicicleta = 1, IdTranca = 1, IdFuncionario = 1
        };

        _bicicletaRepositoryMock.Setup(x => x.IntegrarNaRede(bicicletaRequest)).ReturnsAsync(bicicleta);

        var bicicletaService = new BicicletaService(_bicicletaRepositoryMock.Object);

        // Act
        var result = await bicicletaService.IntegrarNaRede(bicicletaRequest);

        // Assert
        Assert.Equal(bicicleta, result);
    }

    [Fact]
    public async Task DeveRemoverBicicleta()
    {
        // Arrange
        var bicicleta = new Bicicleta(1, "Caloi", "Caloi 10", "Azul", 1, BicicletaStatus.Disponivel);

        _bicicletaRepositoryMock.Setup(x => x.Delete(1)).ReturnsAsync(bicicleta);

        var bicicletaService = new BicicletaService(_bicicletaRepositoryMock.Object);

        // Act
        var result = await bicicletaService.RemoverBicicleta(1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeveRetirarBicicletaDaRede()
    {
        // Arrange
        var bicicleta = new Bicicleta(1, "Caloi", "Caloi 10", "Azul", 1, BicicletaStatus.Disponivel);
        var bicicletaRequest = new RetirarDaRedeRequest
        {
            IdBicicleta = 1, IdTranca = 1, IdFuncionario = 1, StatusAcaoReparador = "Reparar"
        };

        _bicicletaRepositoryMock.Setup(x => x.RetirarDaRede(bicicletaRequest)).ReturnsAsync(bicicleta);

        var bicicletaService = new BicicletaService(_bicicletaRepositoryMock.Object);

        // Act
        var result = await bicicletaService.RetirarDaRede(bicicletaRequest);

        // Assert
        Assert.Equal(bicicleta, result);
    }

    [Fact]
    public async Task DeveAtualizarBicicleta()
    {
        // Arrange
        var bicicleta = new Bicicleta(1, "Caloi", "Caloi 10", "Azul", 1, BicicletaStatus.Disponivel);
        var bicicletaRequest = new NovaBicicletaRequest
        {
            Marca = "Caloi", Modelo = "Caloi 10", Ano = "Azul", Numero = 1, Status = BicicletaStatus.Disponivel
        };

        _bicicletaRepositoryMock.Setup(x => x.Update(1, bicicletaRequest)).ReturnsAsync(bicicleta);

        var bicicletaService = new BicicletaService(_bicicletaRepositoryMock.Object);

        // Act
        var result = await bicicletaService.AtualizarBicicleta(1, bicicletaRequest);

        // Assert
        Assert.Equal(bicicleta, result);
    }

    [Fact]
    public async Task DeveAtualizarStatusBicicleta()
    {
        // Arrange
        var bicicleta = new Bicicleta(1, "Caloi", "Caloi 10", "Azul", 1, BicicletaStatus.Disponivel);

        _bicicletaRepositoryMock.Setup(x => x.AtualizarStatus(1, BicicletaStatus.Disponivel)).ReturnsAsync(bicicleta);

        var bicicletaService = new BicicletaService(_bicicletaRepositoryMock.Object);

        // Act
        var result = await bicicletaService.AtualizarStatus(1, BicicletaStatus.Disponivel);

        // Assert
        Assert.Equal(bicicleta, result);
    }

    [Fact]
    public async Task DeveRetornarBicicletaPorNumero()
    {
        // Arrange
        var bicicleta = new Bicicleta(1, "Caloi", "Caloi 10", "Azul", 1, BicicletaStatus.Disponivel);

        _bicicletaRepositoryMock.Setup(x => x.ObterBicicletaPorNumero(1)).ReturnsAsync(bicicleta);

        var bicicletaService = new BicicletaService(_bicicletaRepositoryMock.Object);

        // Act
        var result = await bicicletaService.ObterBicicletaPorNumero(1);

        // Assert
        Assert.Equal(bicicleta, result);
    }
    
    [Fact]
    public async Task DeveRetornarBicicletaPorNumeroComTranca()
    {
        // Arrange
        var bicicleta = new Bicicleta(1, "Caloi", "Caloi 10", "Azul", 1, BicicletaStatus.Disponivel);

        _bicicletaRepositoryMock.Setup(x => x.ObterBicicletaPorNumero(1)).ReturnsAsync(bicicleta);

        var bicicletaService = new BicicletaService(_bicicletaRepositoryMock.Object);

        // Act
        var result = await bicicletaService.ObterBicicletaPorNumero(1);

        // Assert
        Assert.Equal(bicicleta, result);
    }
    
    [Fact]
    public async Task DeveIntegrarBicicletaNaRedeComTranca()
    {
        // Arrange
        var bicicleta = new Bicicleta(1, "Caloi", "Caloi 10", "Azul", 1, BicicletaStatus.Disponivel);
        var bicicletaRequest = new IntegrarNaRedeRequest
        {
            IdBicicleta = 1, IdTranca = 1, IdFuncionario = 1
        };

        _bicicletaRepositoryMock.Setup(x => x.IntegrarNaRede(bicicletaRequest)).ReturnsAsync(bicicleta);

        var bicicletaService = new BicicletaService(_bicicletaRepositoryMock.Object);

        // Act
        var result = await bicicletaService.IntegrarNaRede(bicicletaRequest);

        // Assert
        Assert.Equal(bicicleta, result);
    }
    
}
