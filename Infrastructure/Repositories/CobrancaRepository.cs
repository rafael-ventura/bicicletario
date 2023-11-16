using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;

namespace bicicletario.Infrastructure.Repositories;

public class CobrancaRepository : ICobrancaRepository
{
    public Task<Cobranca> CriarCobranca(NovaCobrancaRequest cobranca)
    {
        // MANDAR DADO MOCADO COM DADOS DO NOVACOBRANCAREQUEST
        var cobrancaCriada = new Cobranca
        {
            Valor = cobranca.Valor,
            CiclistaId = cobranca.CiclistaId,
        };

        return Task.FromResult(cobrancaCriada);
    }
    
    public Task<Cobranca> ObterCobrancaPorId(int id)
    {
        // MANDAR DADO MOCADO COM DADOS DO NOVACOBRANCAREQUEST
        var cobranca = new Cobranca
        {
            Id = id,
            Valor = 100,
            CiclistaId = 1,
        };

        return Task.FromResult(cobranca);
    }
}
