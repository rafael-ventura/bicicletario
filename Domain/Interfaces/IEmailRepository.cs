using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Domain.Interfaces;

public interface IEmailRepository
{
    Task<Email> EnviarEmail(NovoEmailRequest novoEmailRequest);
}
