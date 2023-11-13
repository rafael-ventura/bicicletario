using System.Net;
using bicicletario.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace bicicletario.Application.Interfaces;

public interface IBicicletaService
{
    public Task<Bicicleta> ObterBicicleta(int id);

    public Task<IEnumerable<Bicicleta>> ObterTodasBicicletas();
    
    public Task<Bicicleta> CriarBicicleta(Bicicleta bicicleta);
    
    public Task<Bicicleta> IntegrarNaRede(Bicicleta bicicleta);
    
    public bool RemoverBicicleta(int id);
    
    public Task<Bicicleta> RetirarDaRede(int idTranca, int idBicicleta, int idFuncionario,
        BicicletaStatus statusAcaoReparador);
    
    public Task<Bicicleta> AtualizarBicicleta(int id, Bicicleta bicicleta);
    
    public Task<Bicicleta> AtualizarStatus(int id, BicicletaStatus status);
    
    public Task<Bicicleta> ObterBicicletaPorNumero(int numero);
    
    
}
