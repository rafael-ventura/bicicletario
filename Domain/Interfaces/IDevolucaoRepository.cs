using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Domain.Interfaces;

public interface IDevolucaoRepository
{
    Task<Devolucao> CriarDevolucao(NovaDevolucaoRequest devolucao);
    
}
