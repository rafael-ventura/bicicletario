using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Services;

public class AluguelService : IAluguelService
{
    private readonly IAluguelRepository _aluguelRepository;


    public AluguelService(IAluguelRepository aluguelRepository)
    {
        _aluguelRepository = aluguelRepository;
    }

    public async Task<Aluguel> CriarAluguel(NovoAluguelRequest request)
    {
        var aluguelCriado = await _aluguelRepository.CriarAluguel(request);

        return aluguelCriado;
    }
}
