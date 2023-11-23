using bicicletario.Domain.dtos.requests;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Interfaces;

public interface IBicicletaService
{
    public Task<Bicicleta> ObterBicicleta(int id);

    public Task<List<Bicicleta>> ObterTodasBicicletas();
    
    public Task<Bicicleta> CriarBicicleta(NovaBicicletaRequest bicicleta);
    
    public Task<Bicicleta> IntegrarNaRede(IntegrarNaRedeRequest request);
    
    public Task<bool> RemoverBicicleta(int id);
    
    public Task<Bicicleta> RetirarDaRede(RetirarDaRedeRequest request);
    
    public Task<Bicicleta> AtualizarBicicleta(int id, NovaBicicletaRequest bicicleta);
    
    public Task<Bicicleta> AtualizarStatus(int id, BicicletaStatus status);
    
    public Task<Bicicleta> ObterBicicletaPorNumero(int numero);
    
    
}
