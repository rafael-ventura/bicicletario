// using bicicletario.Application.Services;
// using bicicletario.Domain.Interfaces;
// using bicicletario.Infrastructure.Repositories;
// using Moq;
//
// namespace bicicletario.Tests;
//
// public class BicicletaInfrastructureTests
// {
//     private readonly Mock<ITrancaRepository> _mockTrancaRepository = new();
//
//
//     [Fact]
//     public async Task DeveRetornarListaDeBicicletas()
//     {
//         var bicicletaRepository = new BicicletaRepository(_mockTrancaRepository.Object);
//         var bicicletaService = new BicicletaService(bicicletaRepository);
//
//         var result = await bicicletaService.ObterTodasBicicletas();
//
//         Assert.NotNull(result);
//     }
//
//     [Fact]
//     public async Task DeveRetornarBicicletaPorId()
//     {
//         var bicicletaRepository = new BicicletaRepository(_mockTrancaRepository.Object);
//         var bicicletaService = new BicicletaService(bicicletaRepository);
//
//         var result = await bicicletaService.ObterBicicleta(1);
//
//         Assert.NotNull(result);
//     }
//     
// }
