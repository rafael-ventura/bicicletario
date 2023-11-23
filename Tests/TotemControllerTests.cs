using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using bicicletario.Domain.dtos.responses;
using bicicletario.Domain.Models;
using bicicletario.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace bicicletario.Tests;

public class TotemControllerTests
{
    private readonly Mock<ITotemService> _totemServiceMock;
    private readonly TotemController _totemController;

    public TotemControllerTests()
    {
        _totemServiceMock = new Mock<ITotemService>();
        _totemController = new TotemController(_totemServiceMock.Object);
    }

    [Fact]
    public async Task GetAll_RetornaOkComTotensMockados_QuandoExistemTotens()
    {
        // Arrange
        var totensMockados = new List<Totem>
        {
            new Totem { Id = 1, Localizacao = "Parque Central", Descricao = "Totem perto da entrada principal" },
            new Totem { Id = 2, Localizacao = "Universidade XY", Descricao = "Totem ao lado da biblioteca" }
        };
        _totemServiceMock.Setup(s => s.ObterTodosTotens()).ReturnsAsync(totensMockados);

        // Act
        var resultado = await _totemController.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var retorno = Assert.IsType<TotemResponse>(okResult.Value);
        Assert.Equal(totensMockados, retorno.Totens);
    }

    [Fact]
    public async Task GetAll_RetornaNotFound_QuandoNenhumTotemEncontrado()
    {
        // Arrange
        _totemServiceMock.Setup(s => s.ObterTodosTotens()).ThrowsAsync(new TotemNaoEncontradoException());

        // Act
        var resultado = await _totemController.GetAll();

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(resultado);
        var retorno = Assert.IsType<TotemResponse>(notFoundResult.Value);
        Assert.Equal("Nenhum totem encontrado.", retorno.Mensagem);
    }

    [Fact]
    public async Task Create_RetornaCreatedAtActionComNovoTotem_QuandoTotemEhCriado()
    {
        // Arrange
        var novoTotemRequest = new NovoTotemRequest
        {
            Descricao = "Totem perto da entrada principal",
            Localizacao = "Parque Central"
        };
        var totemCriado = new Totem
        {
            Id = 1,
            Descricao = novoTotemRequest.Descricao,
            Localizacao = novoTotemRequest.Localizacao
        };
        _totemServiceMock.Setup(s => s.IncluirTotem(novoTotemRequest)).ReturnsAsync(totemCriado);

        // Act
        var resultado = await _totemController.Create(novoTotemRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(resultado);
        Assert.IsType<TotemResponse>(okResult.Value);
    }

    [Fact]
    public async Task Create_RetornaStatusCode500_QuandoExcecaoLancada()
    {
        // Arrange
        var novoTotemRequest = new NovoTotemRequest
        {
            /* Dados do novo totem */
        };
        _totemServiceMock.Setup(s => s.IncluirTotem(novoTotemRequest)).ThrowsAsync(new Exception());

        // Act
        var resultado = await _totemController.Create(novoTotemRequest);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(resultado);
        Assert.Equal(500, objectResult.StatusCode);
    }


    [Fact]
    public async Task Update_RetornaOkComTotemAtualizado_QuandoTotemExiste()
    {
        // Arrange
        var totemAtualizado = new Totem
        {
            /* Dados do totem atualizado */
        };
        _totemServiceMock.Setup(s => s.EditarTotem(totemAtualizado.Id, totemAtualizado)).ReturnsAsync(totemAtualizado);

        // Act
        var resultado = await _totemController.Update(totemAtualizado.Id, totemAtualizado);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var retorno = Assert.IsType<TotemResponse>(okResult.Value);
        Assert.Equal(totemAtualizado, retorno.Totem);
    }


    [Fact]
    public async Task Update_RetornaNotFound_QuandoTotemNaoExiste()
    {
        // Arrange
        var totemAtualizado = new Totem
        {
            /* Dados do totem */
        };
        _totemServiceMock.Setup(s => s.EditarTotem(totemAtualizado.Id, totemAtualizado))
            .ThrowsAsync(new TotemNaoEncontradoException(totemAtualizado.Id));

        // Act
        var resultado = await _totemController.Update(totemAtualizado.Id, totemAtualizado);

        // Assert
        Assert.IsType<NotFoundObjectResult>(resultado);
    }


    [Fact]
    public async Task Delete_VerificaChamadaMetodo_QuandoTotemEhRemovido()
    {
        // Arrange
        const int totemIdParaRemover = 1;
        _totemServiceMock.Setup(s => s.RemoverTotem(totemIdParaRemover)).ReturnsAsync(new Totem());

        // Act
        await _totemController.Delete(totemIdParaRemover);

        // Assert
        _totemServiceMock.Verify(s => s.RemoverTotem(totemIdParaRemover), Times.Once);
    }


    [Fact]
    public async Task Delete_RetornaOk_QuandoTotemEhRemovido()
    {
        // Arrange
        const int totemIdParaRemover = 1;
        _totemServiceMock.Setup(s => s.RemoverTotem(totemIdParaRemover)).ReturnsAsync(new Totem()); // Corrigido

        // Act
        var resultado = await _totemController.Delete(totemIdParaRemover);

        // Assert
        Assert.IsType<OkObjectResult>(resultado);
    }


    [Fact]
    public async Task Delete_RetornaNotFound_QuandoTotemNaoExiste()
    {
        // Arrange
        const int totemIdInexistente = 999;
        _totemServiceMock.Setup(s => s.RemoverTotem(totemIdInexistente))
            .Throws(new TotemNaoEncontradoException(totemIdInexistente));

        // Act
        var resultado = await _totemController.Delete(totemIdInexistente);

        // Assert
        Assert.IsType<NotFoundObjectResult>(resultado);
    }

    [Fact]
    public async Task GetTrancasDoTotem_RetornaOkComTrancas_QuandoTotemExiste()
    {
        // Arrange
        const int totemId = 1;
        var trancasMockadas = new List<Tranca>
        {
            new()
            {
                Id = 1, BicicletaId = 0, Numero = 201, Localizacao = "Parque Central", AnoDeFabricacao = "2020",
                Modelo = "Modelo A", Status = TrancaStatus.Livre
            },
            new()
            {
                Id = 2, BicicletaId = 1, Numero = 202, Localizacao = "Universidade XY", AnoDeFabricacao = "2021",
                Modelo = "Modelo B", Status = TrancaStatus.Ocupada
            }
        };
        _totemServiceMock.Setup(s => s.ListarTrancasDoTotem(totemId)).ReturnsAsync(trancasMockadas);

        // Act
        var resultado = await _totemController.GetTrancasDoTotem(totemId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var response = Assert.IsType<TrancaResponse>(okResult.Value);
        Assert.IsType<List<Tranca>>(response.Trancas);
    }

    [Fact]
    public async Task GetTrancasDoTotem_RetornaNotFound_QuandoTotemNaoExiste()
    {
        // Arrange
        const int totemIdInexistente = 999;
        _totemServiceMock.Setup(s => s.ListarTrancasDoTotem(totemIdInexistente))
            .Throws(new TotemNaoEncontradoException(totemIdInexistente));

        // Act
        var resultado = await _totemController.GetTrancasDoTotem(totemIdInexistente);

        // Assert
        Assert.IsType<NotFoundObjectResult>(resultado);
    }

    [Fact]
    public async Task GetBicicletasDoTotem_RetornaOkComBicicletas_QuandoTotemExiste()
    {
        // Arrange
        const int totemId = 1;
        var bicicletasMockadas = new List<Bicicleta>
        {
            new Bicicleta
            {
                Id = 1, Marca = "Scott", Modelo = "Speedster 200", Ano = "2021", Numero = 101,
                Status = BicicletaStatus.Disponivel
            },
            new Bicicleta
            {
                Id = 2, Marca = "Scott", Modelo = "Speedster 200", Ano = "2021", Numero = 102,
                Status = BicicletaStatus.Disponivel
            }
        };
        _totemServiceMock.Setup(s => s.ListarBicicletasDoTotem(totemId)).ReturnsAsync(bicicletasMockadas);

        // Act
        var resultado = await _totemController.GetBicicletasDoTotem(totemId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var response = Assert.IsType<BicicletaResponse>(okResult.Value);
        Assert.IsType<List<Bicicleta>>(response.Bicicletas);
    }

    [Fact]
    public async Task GetBicicletasDoTotem_RetornaNotFound_QuandoTotemNaoExiste()
    {
        // Arrange
        const int totemIdInexistente = 999;
        _totemServiceMock.Setup(s => s.ListarBicicletasDoTotem(totemIdInexistente))
            .Throws(new TotemNaoEncontradoException(totemIdInexistente));

        // Act
        var resultado = await _totemController.GetBicicletasDoTotem(totemIdInexistente);

        // Assert
        Assert.IsType<NotFoundObjectResult>(resultado);
    }
}
