using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;

namespace bicicletario.Infrastructure.Repositories;

public class DevolucaoRepository : IDevolucaoRepository
{

    public DevolucaoRepository()
    {
        
    }
    
    // mockar o banco de dados
    public async Task<Devolucao> CriarDevolucao(NovaDevolucaoRequest devolucao)
    {
        var devolucaoCriada = new Devolucao
        {
            CiclistaId = devolucao.IdTranca,
            TrancaFimId = devolucao.IdBicicleta
        };

        return await Task.FromResult(devolucaoCriada);
    }
}
