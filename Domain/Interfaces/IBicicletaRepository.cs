using bicicletario.Domain.Models;

namespace bicicletario.Domain.Interfaces;

public interface IBicicletaRepository
{
    public Task<Bicicleta> Get(int id);

    public IEnumerable<Bicicleta> GetAll();

    public Task<Bicicleta> Create(Bicicleta bicicleta);
    
    public Task<Bicicleta> Update(int id, Bicicleta bicicleta);
    
    public Task<Bicicleta> Delete(int id);
    
    public Task<Bicicleta> IntegrarNaRede(int idTotem, int idBicicleta, int idFuncionario);
    
    public Task<Bicicleta> RetirarDaRede(int idTranca, int idBicicleta, int idFuncionario,
        BicicletaStatus statusAcaoReparador);
    
    public Task<Bicicleta> AtualizarStatus(int id, BicicletaStatus status);
    
    public Task<Bicicleta> ObterBicicletaPorNumero(int numero);
    
    
    

    
    
    
}
