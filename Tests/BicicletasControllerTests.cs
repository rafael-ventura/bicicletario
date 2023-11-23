using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
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
            var bicicletas = Assert.IsAssignableFrom<IEnumerable<Bicicleta>>(resultValue.Bicicletas);
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
    }
}
