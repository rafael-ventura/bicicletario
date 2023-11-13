// ReSharper disable once RedundantUsingDirective

using System.Net;
using bicicletario.Application.Exceptions;
using bicicletario.Application.Interfaces;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace bicicletario.Application.Services;

public class BicicletaService : IBicicletaService
{
    private readonly IBicicletaRepository _bicicletaRepository;
    private readonly ITrancaRepository _trancaRepository;
    private readonly IALuguelRepository _aLuguelRepository;

    public BicicletaService(IBicicletaRepository bicicletaRepository)
    {
        _bicicletaRepository = bicicletaRepository;
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

    public Task<Bicicleta> CriarBicicleta(Bicicleta bicicleta)
    {
        var bicicletaCriada = _bicicletaRepository.Create(bicicleta);

        return bicicletaCriada;
    }

    public Task<Bicicleta> IntegrarNaRede(Bicicleta bicicleta)
    {
        var bicicletaIntegrada = _bicicletaRepository.IntegrarNaRede(bicicleta);

        return bicicletaIntegrada;
    }

    
    public Task<Bicicleta> AtualizarBicicleta(int id, Bicicleta bicicleta)
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
        BicicletaStatus statusAcaoReparador)
    {
        //atualizar o status baseado no enum. a documentacao tb diz q esse ecara retira uma bicicelta para reparo ou aposentadoria
        // copilot, consegue fazer um codigo que tire a bicicleta da redes de totens e atualize o status dessa bicicelta para o que vier em statusAcaoReparador?
        // o statusAcaoReparador pode ser "reparo" ou "aposentadoria"

        var bicicleta = _bicicletaRepository.Get(idBicicleta);
        var tranca = _trancaRepository.Get(idTranca);

        // idFuncionario = _aLuguelRepository.Get(idFuncionario);
        if (idFuncionario != null)
        {
            bicicleta = _bicicletaRepository.RetirarDaRede(idTranca, idBicicleta, idFuncionario, statusAcaoReparador);
        }
        else
        {
            throw new FuncionarioNaoAutorizadoException(idFuncionario);
        }

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
