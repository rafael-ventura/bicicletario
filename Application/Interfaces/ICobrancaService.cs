using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Interfaces;

public interface ICobrancaService
{
    Task<Cobranca> CriarCobranca(NovaCobrancaRequest request);
    
    Task<Cobranca> ObterCobrancaPorId(int id);
}
