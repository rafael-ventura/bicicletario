// using bicicletario.Application.Exceptions;
// using bicicletario.Application.Interfaces;
// using bicicletario.Domain.dtos;
// using bicicletario.Domain.Models;
// using bicicletario.WebAPI.Controllers;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
//
// namespace bicicletario.Tests;
//
// public class TotemControllerTests
// {
//     private readonly Mock<ITotemService> _totemServiceMock;
//     private readonly TotemController _totemController;
//
//     public TotemControllerTests()
//     {
//         _totemServiceMock = new Mock<ITotemService>();
//         _totemController = new TotemController(_totemServiceMock.Object);
//     }
//
//     [Fact]
//     public async Task GetAll_RetornaOkComTotensMockados_QuandoExistemTotens()
//     {
//         // Arrange
//         var totensMockados = new List<Totem>
//         {
//             new Totem { Id = 1, Localizacao = "Parque Central", Descricao = "Totem perto da entrada principal" },
//             new Totem { Id = 2, Localizacao = "Universidade XY", Descricao = "Totem ao lado da biblioteca" }
//         };
//         _totemServiceMock.Setup(s => s.ObterTodosTotens()).ReturnsAsync(totensMockados);
//
//         // Act
//         var resultado = await _totemController.GetAll();
//
//         // Assert
//         var okResult = Assert.IsType<OkObjectResult>(resultado);
//         var retorno = Assert.IsType<List<Totem>>(okResult.Value);
//         Assert.Equal(totensMockados, retorno);
//     }
//
//
//     [Fact]
//     public void GetAll_RetornaNotFound_QuandoNenhumTotemEncontrado()
//     {
//         // Arrange
//         _totemServiceMock.Setup(s => s.ObterTodosTotens()).ReturnsAsync(new List<Totem>());
//
//         // Act
//         var result = _totemController.GetAll();
//
//         // Assert
//         Assert.IsType<NotFoundObjectResult>(result);
//     }
//
//
//     [Fact]
//     public void Create_RetornaCreatedAtActionComNovoTotem_QuandoTotemEhCriado()
//     {
//         // Arrange
//         var novoTotemRequest = new NovoTotemRequest
//         {
//             Localizacao = "Novo Local",
//             Descricao = "Descrição do novo totem"
//         };
//         var totemCriado = new Totem
//             { Id = 3, Localizacao = novoTotemRequest.Localizacao, Descricao = novoTotemRequest.Descricao };
//         _totemServiceMock.Setup(s => s.IncluirTotem(novoTotemRequest)).ReturnsAsync(totemCriado);
//
//         // Act
//         var result = _totemController.Create(novoTotemRequest);
//
//         // Assert
//         var actionResult = Assert.IsType<CreatedAtActionResult>(result);
//         Assert.Equal("Create", actionResult.ActionName);
//         Assert.Equal(totemCriado, actionResult.Value);
//     }
//
//     [Fact]
//     public void Create_RetornaStatusCode500_QuandoExcecaoLancada()
//     {
//         // Arrange
//         var novoTotemRequest = new NovoTotemRequest { Localizacao = "Local Teste", Descricao = "Descrição Teste" };
//         _totemServiceMock.Setup(s => s.IncluirTotem(novoTotemRequest)).ThrowsAsync(new Exception());
//
//         // Act
//         var result = _totemController.Create(novoTotemRequest);
//
//         // Assert
//         var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
//         Assert.Equal(500, statusCodeResult.StatusCode);
//     }
//
//
//     [Fact]
//     public void Update_RetornaOkComTotemAtualizado_QuandoTotemExiste()
//     {
//         // Arrange
//         var totemAtualizado = new Totem
//             { Id = 1, Localizacao = "Localização atualizada", Descricao = "Descrição atualizada" };
//         _totemServiceMock.Setup(s => s.EditarTotem(totemAtualizado.Id, totemAtualizado)).ReturnsAsync(totemAtualizado);
//
//         // Act
//         var result = _totemController.Update(totemAtualizado.Id, totemAtualizado);
//
//         // Assert
//         var okResult = Assert.IsType<OkObjectResult>(result);
//         var retorno = Assert.IsType<Totem>(okResult.Value);
//         Assert.Equal(totemAtualizado.Localizacao, retorno.Localizacao);
//         Assert.Equal(totemAtualizado.Descricao, retorno.Descricao);
//     }
//
//     [Fact]
//     public void Update_RetornaNotFound_QuandoTotemNaoExiste()
//     {
//         // Arrange
//         var totemAtualizado = new Totem
//             { Id = 999, Localizacao = "Localização inexistente", Descricao = "Descrição inexistente" };
//         _totemServiceMock.Setup(s => s.EditarTotem(totemAtualizado.Id, totemAtualizado))
//             .Throws(new TotemNaoEncontradoException(totemAtualizado.Id));
//
//         // Act
//         var result = _totemController.Update(totemAtualizado.Id, totemAtualizado);
//
//         // Assert
//         Assert.IsType<NotFoundObjectResult>(result);
//     }
//
//     [Fact]
//     public void Delete_VerificaChamadaMetodo_QuandoTotemEhRemovido()
//     {
//         // Arrange
//         const int totemIdParaRemover = 1;
//         _totemServiceMock.Setup(s => s.RemoverTotem(totemIdParaRemover)).Returns((Task<Totem>)Task.CompletedTask);
//
//         // Act
//         _ = _totemController.Delete(totemIdParaRemover);
//
//         // Assert
//         _totemServiceMock.Verify(s => s.RemoverTotem(totemIdParaRemover), Times.Once);
//     }
//
//
//     [Fact]
//     public void Delete_RetornaOk_QuandoTotemEhRemovido()
//     {
//         // Arrange
//         const int totemIdParaRemover = 1;
//         _totemServiceMock.Setup(s => s.RemoverTotem(totemIdParaRemover)).Returns((Task<Totem>)Task.CompletedTask);
//
//         // Act
//         var result = _totemController.Delete(totemIdParaRemover);
//
//         // Assert
//         Assert.IsType<OkObjectResult>(result);
//     }
//
//     [Fact]
//     public void Delete_RetornaNotFound_QuandoTotemNaoExiste()
//     {
//         // Arrange
//         const int totemIdInexistente = 999;
//         _totemServiceMock.Setup(s => s.RemoverTotem(totemIdInexistente))
//             .Throws(new TotemNaoEncontradoException(totemIdInexistente));
//
//         // Act
//         var result = _totemController.Delete(totemIdInexistente);
//
//         // Assert
//         Assert.IsType<NotFoundObjectResult>(result);
//     }
//
//     [Fact]
//     public void GetTrancasDoTotem_RetornaOkComTrancas_QuandoTotemExiste()
//     {
//         // Arrange
//         const int totemId = 1;
//         var trancasMockadas = new List<Tranca>
//         {
//             new()
//             {
//                 Id = 1, BicicletaId = 0, Numero = 201, Localizacao = "Parque Central", AnoDeFabricacao = "2020",
//                 Modelo = "Modelo A", Status = TrancaStatus.Livre
//             },
//             new()
//             {
//                 Id = 2, BicicletaId = 1, Numero = 202, Localizacao = "Universidade XY", AnoDeFabricacao = "2021",
//                 Modelo = "Modelo B", Status = TrancaStatus.Ocupada
//             }
//         };
//         _totemServiceMock.Setup(s => s.ListarTrancasDoTotem(totemId)).ReturnsAsync(trancasMockadas);
//
//         // Act
//         var result = _totemController.GetTrancasDoTotem(totemId);
//
//         // Assert
//         var okResult = Assert.IsType<OkObjectResult>(result);
//         var retorno = Assert.IsType<List<Tranca>>(okResult.Value);
//         Assert.Equal(trancasMockadas, retorno);
//     }
//
//     [Fact]
//     public void GetTrancasDoTotem_RetornaNotFound_QuandoTotemNaoExiste()
//     {
//         // Arrange
//         const int totemIdInexistente = 999;
//         _totemServiceMock.Setup(s => s.ListarTrancasDoTotem(totemIdInexistente))
//             .Throws(new TotemNaoEncontradoException(totemIdInexistente));
//
//         // Act
//         var result = _totemController.GetTrancasDoTotem(totemIdInexistente);
//
//         // Assert
//         Assert.IsType<NotFoundObjectResult>(result);
//     }
//
//     [Fact]
//     public void GetBicicletasDoTotem_RetornaOkComBicicletas_QuandoTotemExiste()
//     {
//         // Arrange
//         const int totemId = 1;
//         var bicicletasMockadas = new List<Bicicleta>
//         {
//             new Bicicleta
//             {
//                 Id = 1, Marca = "Scott", Modelo = "Speedster 200", Ano = "2021", Numero = 101,
//                 Status = BicicletaStatus.Disponivel
//             },
//             new Bicicleta
//             {
//                 Id = 2, Marca = "Scott", Modelo = "Speedster 200", Ano = "2021", Numero = 102,
//                 Status = BicicletaStatus.Disponivel
//             }
//         };
//         _totemServiceMock.Setup(s => s.ListarBicicletasDoTotem(totemId)).ReturnsAsync(bicicletasMockadas);
//
//         // Act
//         var result = _totemController.GetBicicletasDoTotem(totemId);
//
//         // Assert
//         var okResult = Assert.IsType<OkObjectResult>(result);
//         var retorno = Assert.IsType<List<Bicicleta>>(okResult.Value);
//         Assert.Equal(bicicletasMockadas, retorno);
//     }
//
//     [Fact]
//     public void GetBicicletasDoTotem_RetornaNotFound_QuandoTotemNaoExiste()
//     {
//         // Arrange
//         const int totemIdInexistente = 999;
//         _totemServiceMock.Setup(s => s.ListarBicicletasDoTotem(totemIdInexistente))
//             .Throws(new TotemNaoEncontradoException(totemIdInexistente));
//
//         // Act
//         var result = _totemController.GetBicicletasDoTotem(totemIdInexistente);
//
//         // Assert
//         Assert.IsType<NotFoundObjectResult>(result);
//     }
// }
