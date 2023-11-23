using bicicletario.Application.Services;
using bicicletario.Domain.dtos.requests;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;
using Moq;

namespace bicicletario.Tests;

public class TotemServiceTests
{
    private readonly Mock<ITotemRepository> _mockTotemRepository = new();


    [Fact]
    public async Task DeveRetornarTodosTotens()
    {
        // Arrange
        var totem = new Totem
        {
            Id = 1, Localizacao = "Local 1", Descricao = "Totem 1"
        };
        var totem2 = new Totem
        {
            Id = 2, Localizacao = "Local 2", Descricao = "Totem 2"
        };
        var totem3 = new Totem
        {
            Id = 3, Localizacao = "Local 3", Descricao = "Totem 3"
        };

        var totens = new List<Totem> { totem, totem2, totem3 };

        _mockTotemRepository.Setup(x => x.ObterTodosTotens()).ReturnsAsync(totens);

        var totemService = new TotemService(_mockTotemRepository.Object);

        // Act
        var result = await totemService.ObterTodosTotens();

        // Assert
        Assert.Equal(totens, result);
    }

    [Fact]
    public async Task DeveIncluirTotem()
    {
        // Arrange
        var totem = new Totem
        {
            Id = 1, Localizacao = "Local 1", Descricao = "Totem 1"
        };

        _mockTotemRepository.Setup(x => x.IncluirTotem(It.IsAny<NovoTotemRequest>())).ReturnsAsync(totem);

        var totemService = new TotemService(_mockTotemRepository.Object);

        // Act
        var result = await totemService.IncluirTotem(It.IsAny<NovoTotemRequest>());

        // Assert
        Assert.Equal(totem, result);
    }

    [Fact]
    public async Task DeveEditarTotem()
    {
        // Arrange
        var totem = new Totem
        {
            Id = 1, Localizacao = "Local 1", Descricao = "Totem 1"
        };

        _mockTotemRepository.Setup(x => x.EditarTotem(It.IsAny<int>(), It.IsAny<Totem>())).ReturnsAsync(totem);

        var totemService = new TotemService(_mockTotemRepository.Object);

        // Act
        var result = await totemService.EditarTotem(It.IsAny<int>(), It.IsAny<Totem>());

        // Assert
        Assert.Equal(totem, result);
    }

    [Fact]
    public async Task DeveRemoverTotem()
    {
        // Arrange
        var totem = new Totem
        {
            Id = 1, Localizacao = "Local 1", Descricao = "Totem 1"
        };

        _mockTotemRepository.Setup(x => x.RemoverTotem(It.IsAny<int>())).ReturnsAsync(totem);

        var totemService = new TotemService(_mockTotemRepository.Object);

        // Act
        var result = await totemService.RemoverTotem(It.IsAny<int>());

        // Assert
        Assert.Equal(totem, result);
    }

    [Fact]
    public async Task DeveListarTrancasDoTotem()
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

        _mockTotemRepository.Setup(x => x.ListarTrancasDoTotem(It.IsAny<int>())).ReturnsAsync(trancas);

        var totemService = new TotemService(_mockTotemRepository.Object);

        // Act
        var result = await totemService.ListarTrancasDoTotem(It.IsAny<int>());

        // Assert
        Assert.Equal(trancas, result);
    }

    [Fact]
    public async Task DeveListarBicicletasDoTotem()
    {
        // Arrange
        var bicicleta = new Bicicleta
        {
            Id = 1, Modelo = "Bicicleta 1", Numero = 1, Status = BicicletaStatus.Nova, Ano = "2021", Marca = "Marca 1"
        };
        var bicicleta2 = new Bicicleta
        {
            Id = 2, Modelo = "Bicicleta 2", Numero = 2, Status = BicicletaStatus.Nova, Ano = "2021", Marca = "Marca 2"
        };
        var bicicleta3 = new Bicicleta
        {
            Id = 3, Modelo = "Bicicleta 3", Numero = 3, Status = BicicletaStatus.Nova, Ano = "2021", Marca = "Marca 3"
        };

        var bicicletas = new List<Bicicleta> { bicicleta, bicicleta2, bicicleta3 };

        _mockTotemRepository.Setup(x => x.ListarBicicletasDoTotem(It.IsAny<int>())).ReturnsAsync(bicicletas);

        var totemService = new TotemService(_mockTotemRepository.Object);

        // Act
        var result = await totemService.ListarBicicletasDoTotem(It.IsAny<int>());

        // Assert
        Assert.Equal(bicicletas, result);
    }

    [Fact]
    public async Task DeveObterTotemPorId()
    {
        // Arrange
        var totem = new Totem
        {
            Id = 1, Localizacao = "Local 1", Descricao = "Totem 1"
        };
        _mockTotemRepository.Setup(x => x.ObterTotemPorId(1)).ReturnsAsync(totem);

        var totemService = new TotemService(_mockTotemRepository.Object);

        // Act
        var result = await totemService.ObterTotem(1);

        // Assert
        Assert.Equal(totem, result);
    }
}
