using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Domain.Interfaces;

public interface ITrancaRepository
{
    public Task<IEnumerable<Tranca>> GetAll();
    public Task<Tranca> Get(int id);

    public Task<Tranca> Create(NovaTrancaRequest tranca);

    public Task<Tranca> UpdateBicicleta(int id, Tranca tranca);

    public Task<Tranca> Delete(int id);

    public Task<Tranca> IntegrarNaRede(int idTranca);

    public Task<Tranca> RetirarDaRede(int idTranca, RetirarDaRedeRequest retirarDaRedeRequest);

    public Task<Tranca> AtualizarStatus(int id, AcaoEnum status);

    public Task<Tranca> TrancarTranca(int idTranca);

    public Task<Tranca> DestrancarTranca(int idTranca);
}
