using bicicletario.Domain.dtos.requests;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Interfaces;

public interface ITrancaService
{
    public Task<List<Tranca>> ObterTodasTrancas();
    public Task<Tranca> ObterTrancaPorId(int id);
    public Task<Tranca> IncluirTranca(NovaTrancaRequest novaTrancaRequest);
    public Task<Tranca> AtualizarTranca(int id, Tranca trancaAtualizada);
    public Task<Tranca> RemoverTranca(int id);
    public Task<Tranca> IntegrarNaRede(int idTranca);
    public Task<Tranca> RetirarDaRede(int idTranca, RetirarDaRedeRequest retiradaTrancaRequest);
    public Task<Tranca> AtualizarStatus(int id, AcaoEnum status);
    public Task<Tranca> TrancarTranca(int idTranca);
    public Task<Tranca> DestrancarTranca(int idTranca);
}
