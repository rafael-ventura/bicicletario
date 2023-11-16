using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Services;

public class CobrancaService : ICobrancaService
{
    private readonly ICobrancaRepository _cobrancaRepository;

    public CobrancaService(ICobrancaRepository cobrancaRepository)
    {
        _cobrancaRepository = cobrancaRepository;
    }

    public async Task<Cobranca> CriarCobranca(NovaCobrancaRequest request)
    {
        var cobrancaCriada = await _cobrancaRepository.CriarCobranca(request);

        return cobrancaCriada;
    }
    
    public async Task<Cobranca> ObterCobrancaPorId(int id)
    {
        var cobranca = await _cobrancaRepository.ObterCobrancaPorId(id);

        return cobranca;
    }
}
