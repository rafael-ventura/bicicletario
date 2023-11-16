using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Services;

public class BicicletaService : IBicicletaService
{
    private readonly IBicicletaRepository _bicicletaRepository;
    private readonly ITrancaRepository _trancaRepository;
    private readonly ITotemRepository _totemRepository;

    public BicicletaService(IBicicletaRepository bicicletaRepository, ITrancaRepository trancaRepository,
        ITotemRepository totemRepository)
    {
        _bicicletaRepository = bicicletaRepository;
        _trancaRepository = trancaRepository;
        _totemRepository = totemRepository;
    }

    public Task<Bicicleta> ObterBicicleta(int id)
    {
        var bicicleta = _bicicletaRepository.Get(id);

        if (bicicleta == null)
            throw new BicicletaNaoEncontradaException(id);

        return bicicleta;
    }

    public Task<IEnumerable<Bicicleta>> ObterTodasBicicletas()
    {
        var bicicletas = _bicicletaRepository.GetAll();

        var obterTodasBicicletas = bicicletas as Bicicleta[] ?? bicicletas.ToArray();
        if (bicicletas == null || !obterTodasBicicletas.Any())
            throw new BicicletaNaoEncontradaException();

        return Task.FromResult<IEnumerable<Bicicleta>>(obterTodasBicicletas);
    }

    public Task<Bicicleta> CriarBicicleta(NovaBicicletaRequest bicicleta)
    {
        var bicicletaCriada = _bicicletaRepository.Create(bicicleta);

        return bicicletaCriada;
    }

    public Task<Bicicleta> IntegrarNaRede(int idTotem, int idTranca, int idFuncionario)
    {
        var bicicletaIntegrada = _bicicletaRepository.IntegrarNaRede(idTotem, idTranca, idFuncionario);

        return bicicletaIntegrada;
    }

    
    public Task<Bicicleta> AtualizarBicicleta(int id, NovaBicicletaRequest bicicleta)
    {
        var bicicletaAtualizada = _bicicletaRepository.Update(id, bicicleta);

        return bicicletaAtualizada;
    }


    public bool RemoverBicicleta(int id)
    {
        var bicicletaRemovida = _bicicletaRepository.Delete(id);

        if (bicicletaRemovida == null)
            throw new BicicletaNaoEncontradaException(id);
        
        return true;
    }

    public Task<Bicicleta> RetirarDaRede(int idTranca, int idBicicleta, int idFuncionario,
        string statusAcaoReparador)
    {

        var bicicleta = _bicicletaRepository.Get(idBicicleta);
        var tranca = _trancaRepository.Get(idTranca);

        // idFuncionario = _totemRepository.Get(idFuncionario);
        bicicleta = _bicicletaRepository.RetirarDaRede(idTranca, idBicicleta, idFuncionario, statusAcaoReparador);

        return bicicleta;
    }

    // metodo para atualizar status
    public Task<Bicicleta> AtualizarStatus(int id, BicicletaStatus status)
    {
        var bicicletaAtualizada = _bicicletaRepository.AtualizarStatus(id, status);

        return bicicletaAtualizada;
    }

    // metodo para pegar bicicleta pelo Numero
    public Task<Bicicleta> ObterBicicletaPorNumero(int numero)
    {
        var bicicleta = _bicicletaRepository.ObterBicicletaPorNumero(numero);
        if (bicicleta == null)
            throw new BicicletaNaoEncontradaException(numero);

        return bicicleta;
    }
}
