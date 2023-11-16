using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Infrastructure.Repositories;

public class AluguelRepository
{
    public AluguelRepository()
    {
    }

    public Task<Aluguel> CriarAluguel(NovoAluguelRequest request)
    {
        var aluguel = new Aluguel
        {
            CiclistaId = request.idCiclista,
            TrancaInicioId = request.TrancaInicioId
        };

        return Task.FromResult(aluguel);
    }
}
