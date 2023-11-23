using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos.requests;
using bicicletario.Domain.dtos.responses;
using bicicletario.Domain.Models;
using bicicletario.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace bicicletario.Tests
{
    public class BicicletasControllerTests
    {
        private readonly Mock<IBicicletaService> _bicicletaServiceMock;
        private readonly BicicletaController _bicicletaController;

        public BicicletasControllerTests()
        {
            _bicicletaServiceMock = new Mock<IBicicletaService>();
            _bicicletaController = new BicicletaController(_bicicletaServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkWithBicicletas_WhenBicicletasExist()
        {
            // Arrange
            var mockBicicletas = new List<Bicicleta>
            {
                new Bicicleta
                {
                    Id = 1, Marca = "Marca A", Modelo = "Modelo A", Ano = "2021", Numero = 101,
                    Status = BicicletaStatus.Disponivel
                },
                new Bicicleta
                {
                    Id = 2, Marca = "Marca B", Modelo = "Modelo B", Ano = "2022", Numero = 102,
                    Status = BicicletaStatus.EmUso
                },
            };

            _bicicletaServiceMock.Setup(s => s.ObterTodasBicicletas()).ReturnsAsync(mockBicicletas);

            // Act
            var actionResult = await _bicicletaController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var resultValue = Assert.IsType<BicicletaResponse>(okResult.Value);
            Assert.Equal(mockBicicletas, resultValue.Bicicletas);
        }


        [Fact]
        public async Task GetAll_ReturnsNotFound_WhenNoBicicletasExist()
        {
            // Arrange
            _bicicletaServiceMock.Setup(s => s.ObterTodasBicicletas())
                .ThrowsAsync(new BicicletaNaoEncontradaException());

            // Act
            var actionResult = await _bicicletaController.GetAll();

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult);
        }

        [Fact]
        public async Task Post_ReturnsCreatedWithBicicleta_WhenBicicletaIsValid()
        {
            // Arrange
            var mockBicicleta = new Bicicleta
            {
                Id = 1, Marca = "Marca A", Modelo = "Modelo A", Ano = "2021", Numero = 101,
                Status = BicicletaStatus.Disponivel
            };

            _bicicletaServiceMock.Setup(s => s.CriarBicicleta(It.IsAny<NovaBicicletaRequest>()))
                .ReturnsAsync(mockBicicleta);

            // Act
            var actionResult = await _bicicletaController.Post(It.IsAny<NovaBicicletaRequest>());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var resultValue = Assert.IsType<BicicletaResponse>(okResult.Value);
            Assert.Equal(mockBicicleta, resultValue.Bicicleta);
        }

        [Fact]
        public async Task Post_ReturnsBadRequest_WhenBicicletaIsInvalid()
        {
            // Arrange
            var mockRequest = new NovaBicicletaRequest
            {
                /* ... */
            };
            _bicicletaServiceMock.Setup(s => s.CriarBicicleta(mockRequest))
                .ThrowsAsync(new DadosInvalidosException());

            // Act
            var actionResult = await _bicicletaController.Post(mockRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
        }


        [Fact]
        public async Task Get_ReturnsOkWithBicicleta_WhenBicicletaExists()
        {
            // Arrange
            var mockBicicleta = new Bicicleta
            {
                Id = 1, Marca = "Marca A", Modelo = "Modelo A", Ano = "2021", Numero = 101,
                Status = BicicletaStatus.Disponivel
            };

            _bicicletaServiceMock.Setup(s => s.ObterBicicleta(It.IsAny<int>()))
                .ReturnsAsync(mockBicicleta);

            // Act
            var actionResult = await _bicicletaController.Get(It.IsAny<int>());

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task Get_ReturnsNotFound_WhenBicicletaDoesNotExist()
        {
            // Arrange
            _bicicletaServiceMock.Setup(s => s.ObterBicicleta(It.IsAny<int>()))
                .ThrowsAsync(new BicicletaNaoEncontradaException());

            // Act
            var actionResult = await _bicicletaController.Get(It.IsAny<int>());

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult);
        }


        [Fact]
        public async Task Put_ReturnsOkWithBicicleta_WhenBicicletaExists()
        {
            // Arrange
            var mockBicicleta = new Bicicleta
            {
                Id = 1, Marca = "Marca A", Modelo = "Modelo A", Ano = "2021", Numero = 101,
                Status = BicicletaStatus.Disponivel
            };

            _bicicletaServiceMock.Setup(s => s.AtualizarBicicleta(It.IsAny<int>(), It.IsAny<NovaBicicletaRequest>()))
                .ReturnsAsync(mockBicicleta);

            // Act
            var actionResult = await _bicicletaController.Update(It.IsAny<int>(), It.IsAny<NovaBicicletaRequest>());

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task Put_ReturnsNotFound_WhenBicicletaDoesNotExist()
        {
            // Arrange
            _bicicletaServiceMock.Setup(s => s.AtualizarBicicleta(It.IsAny<int>(), It.IsAny<NovaBicicletaRequest>()))
                .ThrowsAsync(new BicicletaNaoEncontradaException());

            // Act
            var actionResult = await _bicicletaController.Update(It.IsAny<int>(), It.IsAny<NovaBicicletaRequest>());

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult);
        }


        [Fact]
        public async Task Delete_ReturnsOkWithBicicleta_WhenBicicletaExists()
        {
            // Arrange
            const int bicicletaId = 1;
            _bicicletaServiceMock.Setup(s => s.RemoverBicicleta(bicicletaId))
                .Returns(Task.FromResult(true));

            // Act
            var actionResult = await _bicicletaController.Delete(bicicletaId);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task IntegrarNaRede_ReturnsOkWithBicicleta_WhenBicicletaExists()
        {
            // Arrange
            var mockBicicleta = new Bicicleta
            {
                Id = 1, Marca = "Marca A", Modelo = "Modelo A", Ano = "2021", Numero = 101,
                Status = BicicletaStatus.Disponivel
            };

            _bicicletaServiceMock.Setup(s => s.IntegrarNaRede(It.IsAny<IntegrarNaRedeRequest>()))
                .ReturnsAsync(mockBicicleta);

            // Act
            var actionResult = await _bicicletaController.IntegrarNaRede(It.IsAny<IntegrarNaRedeRequest>());

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task RetirarDaRede_ReturnsOkWithBicicleta_WhenBicicletaExists()
        {
            // Arrange
            var mockBicicleta = new Bicicleta
            {
                Id = 1, Marca = "Marca A", Modelo = "Modelo A", Ano = "2021", Numero = 101,
                Status = BicicletaStatus.Disponivel
            };

            _bicicletaServiceMock.Setup(s => s.RetirarDaRede(It.IsAny<RetirarDaRedeRequest>()))
                .ReturnsAsync(mockBicicleta);

            // Act
            var actionResult = await _bicicletaController.RetirarDaRede(It.IsAny<RetirarDaRedeRequest>());

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task RetirarDaRede_ReturnsNotFound_WhenBicicletaDoesNotExist()
        {
            // Arrange
            _bicicletaServiceMock.Setup(s => s.RetirarDaRede(It.IsAny<RetirarDaRedeRequest>()))
                .ThrowsAsync(new BicicletaNaoEncontradaException());

            // Act
            var actionResult = await _bicicletaController.RetirarDaRede(It.IsAny<RetirarDaRedeRequest>());

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult);
        }


        [Fact]
        public async Task RetirarDaRede_ReturnsBadRequest_WhenFuncionarioIsNotAuthorized()
        {
            // Arrange
            var mockRequest = new RetirarDaRedeRequest
            {
                /* ... */
            };
            _bicicletaServiceMock.Setup(s => s.RetirarDaRede(mockRequest))
                .ThrowsAsync(new FuncionarioNaoAutorizadoException());

            // Act
            var actionResult = await _bicicletaController.RetirarDaRede(mockRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public async Task AtualizarStatus_ReturnsOkWithBicicleta_WhenBicicletaExists()
        {
            // Arrange
            var mockBicicleta = new Bicicleta
            {
                Id = 1, Marca = "Marca A", Modelo = "Modelo A", Ano = "2021", Numero = 101,
                Status = BicicletaStatus.Disponivel
            };

            _bicicletaServiceMock.Setup(s => s.AtualizarStatus(It.IsAny<int>(), It.IsAny<BicicletaStatus>()))
                .ReturnsAsync(mockBicicleta);

            // Act
            var actionResult =
                await _bicicletaController.AtualizarStatus(It.IsAny<int>(), It.IsAny<BicicletaStatus>());

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task AtualizarStatus_ReturnsNotFound_WhenBicicletaDoesNotExist()
        {
            // Arrange
            _bicicletaServiceMock.Setup(s => s.AtualizarStatus(It.IsAny<int>(), It.IsAny<BicicletaStatus>()))
                .ThrowsAsync(new BicicletaNaoEncontradaException());

            // Act
            var actionResult =
                await _bicicletaController.AtualizarStatus(It.IsAny<int>(), It.IsAny<BicicletaStatus>());

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult);
        }


        [Fact]
        public async Task ObterBicicletaPorNumero_ReturnsOkWithBicicleta_WhenBicicletaExists()
        {
            // Arrange
            var mockBicicleta = new Bicicleta
            {
                Id = 1, Marca = "Marca A", Modelo = "Modelo A", Ano = "2021", Numero = 101,
                Status = BicicletaStatus.Disponivel
            };

            _bicicletaServiceMock.Setup(s => s.ObterBicicletaPorNumero(It.IsAny<int>()))
                .ReturnsAsync(mockBicicleta);

            // Act
            var actionResult = await _bicicletaController.ObterBicicletaPorNumero(It.IsAny<int>());

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task ObterBicicletaPorNumero_ReturnsNotFound_WhenBicicletaDoesNotExist()
        {
            // Arrange
            _bicicletaServiceMock.Setup(s => s.ObterBicicletaPorNumero(It.IsAny<int>()))
                .ThrowsAsync(new BicicletaNaoEncontradaException());

            // Act
            var actionResult = await _bicicletaController.ObterBicicletaPorNumero(It.IsAny<int>());

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult);
        }
    }
}
