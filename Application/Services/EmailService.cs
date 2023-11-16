using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Services;

public class EmailService : IEmailService
{
    private readonly IEmailRepository _emailRepository;

    public EmailService(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public async Task<Email> EnviarEmail(NovoEmailRequest novoEmailRequest)
    {
        var email = await _emailRepository.EnviarEmail(novoEmailRequest);

        return email;
    }
}