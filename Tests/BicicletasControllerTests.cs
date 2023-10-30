using BicicletarioAPI.Application;
using BicicletarioAPI.Application.Interfaces;
using BicicletarioAPI.Application.Services;
using BicicletarioAPI.Domain;
using BicicletarioAPI.Domain.Models;
using BicicletarioAPI.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BicicletarioAPI.Tests
{
    public class BicicletasControllerTests
    {
        [Fact]
        public void Get_ReturnsOkResult_WithBicicleta()
        {
            // Arrange
            var mockService = new Mock<IBicicletaService>();
            var testBicicleta = new Bicicleta { Id = 1, Modelo = "Mountain Bike" };
            mockService.Setup(service => service.ObterBicicleta(1)).ReturnsAsync(testBicicleta);

            var controller = new BicicletasController(mockService.Object);

            // Act
            var result = controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Bicicleta>(okResult.Value);
            Assert.Equal(testBicicleta, returnValue);
        }
    }
}
