using bicicletario.Application.Exceptions;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bicicletario.WebAPI.Controllers;

public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    // POST: /enviarEmail
    [HttpPost]
    public async Task<IActionResult> EnviarEmail([FromBody] NovoEmailRequest novoEmailRequest)
    {
        // Verifica se o campo email é nulo ou vazio
        if (string.IsNullOrEmpty(novoEmailRequest?.EnderecoEmail))
        {
            throw new EmailInvalidoException("O campo email é obrigatório.");
        }

        try
        {
            var email = await _emailService.EnviarEmail(novoEmailRequest);
            return CreatedAtAction(nameof(EnviarEmail), new { id = email.Id }, email);
        }
        catch (EmailInvalidoException)
        {
            throw new EmailInvalidoException();
        }
        catch (EmailNaoExisteException)
        {
            throw new EmailNaoExisteException();
        }
    }
}
