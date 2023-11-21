// using bicicletario.Application.Interfaces;
// using bicicletario.Domain.Models;
// using bicicletario.WebAPI.Controllers;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
//
// namespace bicicletario.Tests
// {
//     public class BicicletasControllerTests
//     {
//         private readonly Mock<IBicicletaService> _bicicletaServiceMock;
//         private readonly BicicletaController _bicicletaController;
//
//         public BicicletasControllerTests()
//         {
//             _bicicletaServiceMock = new Mock<IBicicletaService>();
//             _bicicletaController = new BicicletaController(_bicicletaServiceMock.Object);
//         }
//
//         [Fact]
//         public async Task GetAll_ReturnsOkWithBicicletas_WhenBicicletasExist()
//         {
//             // Arrange
//             var mockBicicletas = new List<Bicicleta>
//             {
//                 new Bicicleta
//                 {
//                     Id = 1, Marca = "Marca", Modelo = "Modelo", Ano = "2023", Numero = 100,
//                     Status = BicicletaStatus.Disponivel
//                 },
//                 // Outras bicicletas
//             };
//             _bicicletaServiceMock.Setup(s => s.ObterTodasBicicletas()).ReturnsAsync(mockBicicletas);
//
//             // Act
//             var actionResult = await _bicicletaController.GetAll();
//
//             // Assert
//             var okResult = Assert.IsType<OkObjectResult>(actionResult);
//             var resultValue = Assert.IsAssignableFrom<IEnumerable<Bicicleta>>(okResult.Value);
//             Assert.Equal(mockBicicletas.Count, resultValue.Count());
//         }
//
//
//         [Fact]
//         public async Task GetAll_ReturnsNotFound_WhenNoBicicletasExist()
//         {
//             // Arrange
//             var bicicletas = new List<Bicicleta>();
//             _bicicletaServiceMock.Setup(s => s.ObterTodasBicicletas()).ReturnsAsync(bicicletas);
//
//             // Act
//             var actionResult = await _bicicletaController.GetAll();
//
//             // Assert
//             Assert.IsType<NotFoundObjectResult>(actionResult);
//         }
//
//     }
// }
