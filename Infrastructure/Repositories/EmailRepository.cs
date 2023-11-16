using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;

namespace bicicletario.Infrastructure.Repositories;

public class EmailRepository : IEmailRepository
{
    public Task<Email> EnviarEmail(NovoEmailRequest novoEmailRequest)
    {
        // MANDAR DADO MOCADO COM DADOS DO NOVOEMAILREQUEST
        var email = new Email
        {
            Assunto = novoEmailRequest.Assunto,
            EnderecoEmail = novoEmailRequest.EnderecoEmail,
            Mensagem = novoEmailRequest.Mensagem
        };

        return Task.FromResult(email);
    }
}
