using System.Net;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace bicicletario.Application.Interfaces;

public interface IBicicletaService
{
    public Task<Bicicleta> ObterBicicleta(int id);

    public Task<IEnumerable<Bicicleta>> ObterTodasBicicletas();
    
    public Task<Bicicleta> CriarBicicleta(NovaBicicletaRequest bicicleta);
    
    public Task<Bicicleta> IntegrarNaRede(int idTotem, int idTranca, int idFuncionario);
    
    public bool RemoverBicicleta(int id);
    
    public Task<Bicicleta> RetirarDaRede(int idTranca, int idBicicleta, int idFuncionario,
        string statusAcaoReparador);
    
    public Task<Bicicleta> AtualizarBicicleta(int id, NovaBicicletaRequest bicicleta);
    
    public Task<Bicicleta> AtualizarStatus(int id, BicicletaStatus status);
    
    public Task<Bicicleta> ObterBicicletaPorNumero(int numero);
    
    
}
