using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Services;

public class TrancaService : ITrancaService
{
    private readonly ITrancaRepository _trancaRepository;
    private readonly IBicicletaRepository _bicicletaRepository;
    private readonly ITotemRepository _totemRepository;

    public TrancaService(ITrancaRepository trancaRepository, IBicicletaRepository bicicletaRepository,
        ITotemRepository totemRepository)
    {
        _trancaRepository = trancaRepository;
        _bicicletaRepository = bicicletaRepository;
        _totemRepository = totemRepository;
    }

    public Task<List<Tranca>> ObterTodasTrancas()
    {
        var trancas = _trancaRepository.GetAll();

        if (trancas == null || !trancas.Result.Any())
            throw new TrancaNaoEncontradaException();

        return trancas;
    }

    public Task<Tranca> ObterTrancaPorId(int id)
    {
        var tranca = _trancaRepository.Get(id);

        if (tranca == null)
            throw new TrancaNaoEncontradaException(id);

        return tranca;
    }

    public Task<Tranca> IncluirTranca(NovaTrancaRequest novaTrancaRequest)
    {
        var trancaCriada = _trancaRepository.Create(novaTrancaRequest);

        return trancaCriada;
    }

    public Task<Tranca> AtualizarTranca(int id, Tranca trancaAtualizada)
    {
        var trancaEditada = _trancaRepository.UpdateBicicleta(id, trancaAtualizada);

        return trancaEditada;
    }

    public Task<Tranca> RemoverTranca(int id)
    {
        var trancaRemovida = _trancaRepository.Delete(id);

        return trancaRemovida;
    }

    public Task<Tranca> IntegrarNaRede(int idTranca)
    {
        var trancaIntegrada = _trancaRepository.IntegrarNaRede(idTranca);

        return trancaIntegrada;
    }

    public Task<Tranca> RetirarDaRede(int idTranca, RetirarDaRedeRequest retiradaTrancaRequest)
    {
        var trancaRetirada = _trancaRepository.RetirarDaRede(idTranca, retiradaTrancaRequest);

        return trancaRetirada;
    }

    public Task<Tranca> AtualizarStatus(int id, AcaoEnum status)
    {
        var trancaAtualizada = _trancaRepository.AtualizarStatus(id, status);

        return trancaAtualizada;
    }

    public Task<Tranca> TrancarTranca(int idTranca)
    {
        var trancaTrancada = _trancaRepository.TrancarTranca(idTranca);

        return trancaTrancada;
    }

    public Task<Tranca> DestrancarTranca(int idTranca)
    {
        var trancaDestrancada = _trancaRepository.DestrancarTranca(idTranca);

        return trancaDestrancada;
    }
}
