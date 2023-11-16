using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Domain.Interfaces;

public interface ICobrancaRepository
{
    Task<Cobranca> CriarCobranca(NovaCobrancaRequest cobranca);
    
    Task<Cobranca> ObterCobrancaPorId(int id);
}
