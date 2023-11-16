using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace bicicletario.Tests;

public class EmailControllerTest
{
    private readonly Mock<IEmailService> _emailRepositoryMock;
    private readonly EmailController _emailController;

    public EmailControllerTest()
    {
        _emailRepositoryMock = new Mock<IEmailService>();
        _emailController = new EmailController(_emailRepositoryMock.Object);
    }

    [Fact]
    public async Task EnviarEmail_QuandoEmailForInvalido_DeveRetornarBadRequest()
    {
        // Arrange
        var novoEmailRequest = new NovoEmailRequest
        {
            Assunto = "Teste",
            EnderecoEmail = null,
            Mensagem = "Teste"
        };

        // Act
        var result = await _emailController.EnviarEmail(novoEmailRequest);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task EnviarEmail_QuandoEmailForValido_DeveRetornarOk()
    {
        // Arrange
        var novoEmailRequest = new NovoEmailRequest
        {
            Assunto = "Teste",
            EnderecoEmail = "teste@gmail.com",
            Mensagem = "Teste"
        };

        // Act
        var result = await _emailController.EnviarEmail(novoEmailRequest);

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }
}
