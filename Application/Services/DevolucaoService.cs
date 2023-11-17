using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Services;

public class DevolucaoService : IDevolucaoService
{
    private readonly IDevolucaoRepository _devolucaoRepository;

    public DevolucaoService(IDevolucaoRepository devolucaoRepository)
    {
        _devolucaoRepository = devolucaoRepository;
    }

    
    public async Task<Devolucao> CriarDevolucao(NovaDevolucaoRequest request)
    {
        if (request.IdTranca == 0)
        {
            throw new Exception("Ciclista não encontrado");
        }
        
        
        var devolucaoCriada = await _devolucaoRepository.CriarDevolucao(request);

        return devolucaoCriada;
    }
}
