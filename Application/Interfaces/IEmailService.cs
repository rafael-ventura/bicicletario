using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Interfaces;

public interface IEmailService
{
    Task<Email> EnviarEmail(NovoEmailRequest novoEmailRequest);
}
