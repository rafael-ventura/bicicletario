using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Domain.Interfaces;

public interface IEmailService
{
    Task<Email> EnviarEmail(NovoEmailRequest novoEmailRequest);
}
