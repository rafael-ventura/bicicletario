using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Interfaces;

public interface IDevolucaoService
{
    Task<Devolucao> CriarDevolucao(NovaDevolucaoRequest request);
}
