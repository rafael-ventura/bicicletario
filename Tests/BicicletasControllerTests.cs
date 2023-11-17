using bicicletario.Application.Interfaces;
using bicicletario.Domain.Models;
using bicicletario.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace bicicletario.Tests
{
    public class BicicletasControllerTests
    {
        private readonly Mock<IBicicletaService> _bicicletaServiceMock;
        private readonly BicicletasController _bicicletasController;

        public BicicletasControllerTests()
        {
            _bicicletaServiceMock = new Mock<IBicicletaService>();
            _bicicletasController = new BicicletasController(_bicicletaServiceMock.Object);
        }

        [Fact]
        public async Task Get_Bicicleta_ById()
        {
            // Arrange
            var id = 1;
            var bicicleta = new Bicicleta();
            _bicicletaServiceMock.Setup(x => x.ObterBicicleta(id)).ReturnsAsync(bicicleta);

            // Act
            var result = await _bicicletasController.Get(id);

            // Assert
            Assert.IsType<ActionResult<Bicicleta>>(result);
        }

        [Fact]
        public async Task Get_Bicicleta_ById_NotFound()
        {
            // Arrange
            var id = 1;
            _bicicletaServiceMock.Setup(x => x.ObterBicicleta(id)).ReturnsAsync((Bicicleta)null!);

            // Act
            var result = await _bicicletasController.Get(id);

            // Assert
            Assert.IsType<ActionResult<Bicicleta>>(result);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Get_Bicicleta_ByNumero()
        {
            // Arrange
            var numero = 1;
            var bicicleta = new Bicicleta();
            _bicicletaServiceMock.Setup(x => x.ObterBicicletaPorNumero(numero)).ReturnsAsync(bicicleta);

            // Act
            var result = await _bicicletasController.ObterBicicletaPorNumero(numero);

            // Assert
            Assert.IsType<ActionResult<Bicicleta>>(result);
        }

        [Fact]
        public async Task Get_Bicicleta_ByNumero_NotFound()
        {
            // Arrange
            var numero = 1;
            _bicicletaServiceMock.Setup(x => x.ObterBicicletaPorNumero(numero)).ReturnsAsync((Bicicleta)null!);

            // Act
            var result = await _bicicletasController.ObterBicicletaPorNumero(numero);

            // Assert
            Assert.IsType<ActionResult<Bicicleta>>(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
