using System.Threading.Tasks;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.Models;
using bicicletario.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace bicicletario.Tests
{
    public class BicicletasControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOkResult_WithBicicleta()
        {
            // Arrange
            var mockService = new Mock<IBicicletaService>();
            var testBicicleta = new Bicicleta { Id = 1, Modelo = "Modelo", Marca = "Marca", Ano = 2021, Numero = 1, Status = BicicletaStatus.NOVA };
            mockService.Setup(service => service.ObterBicicleta(1)).ReturnsAsync(testBicicleta);

            var controller = new BicicletasController(mockService.Object);

            // Act
            var result = await controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Bicicleta>(okResult.Value);
            Assert.Equal(testBicicleta, returnValue);
        }

        [Fact]
        public async Task Get_ReturnsNotFoundResult_WhenBicicletaIsNotFound()
        {
            // Arrange
            var mockService = new Mock<IBicicletaService>();
            mockService.Setup(service => service.ObterBicicleta(1))!.ReturnsAsync((Bicicleta) null!);

            var controller = new BicicletasController(mockService.Object);

            // Act
            var result = await controller.Get(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfBicicletas()
        {
            // Arrange
            var mockService = new Mock<IBicicletaService>();
            var testBicicleta = new Bicicleta { Id = 1, Modelo = "Modelo", Marca = "Marca", Ano = 2021, Numero = 1, Status = BicicletaStatus.NOVA };
        }

    }
    
}
