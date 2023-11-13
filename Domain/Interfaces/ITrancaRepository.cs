using bicicletario.Domain.Models;

namespace bicicletario.Domain.Interfaces;

public interface ITrancaRepository
{
    public Task<Tranca> Get(int id);

    public IEnumerable<Tranca> GetAll();

    public Task<Tranca> Create(Tranca tranca);
    
    public Task<Tranca> Update(int id, Tranca tranca);
    
    public Task<Tranca> Delete(int id);
    
    public Task<Tranca> IntegrarNaRede(Tranca tranca);
    
    public Task<Tranca> RetirarDaRede(int idTranca, int idBicicleta, int idFuncionario,
        TrancaStatus statusAcaoReparador);
    
    public Task<Tranca> AtualizarStatus(int id, TrancaStatus status);
    
    public Task<Tranca> ObterTrancaPorNumero(int numero);
}
