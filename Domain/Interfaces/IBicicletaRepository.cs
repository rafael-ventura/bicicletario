using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Domain.Interfaces;

public interface IBicicletaRepository
{
    public Task<Bicicleta> Get(int id);

    public List<Bicicleta> GetAll();
    
    public Task<Bicicleta> Create(NovaBicicletaRequest bicicleta);

    public Task<Bicicleta> Update(int id, NovaBicicletaRequest bicicleta);

    public Task<Bicicleta> Delete(int id);

    public Task<Bicicleta> IntegrarNaRede(IntegrarNaRedeRequest request);

    public Task<Bicicleta> RetirarDaRede(RetirarDaRedeRequest request);

    public Task<Bicicleta> AtualizarStatus(int id, BicicletaStatus status);

    public Task<Bicicleta> ObterBicicletaPorNumero(int numero);
}
