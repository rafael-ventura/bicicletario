using bicicletario.Application.Exceptions;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;
using Newtonsoft.Json;

namespace bicicletario.Infrastructure.Repositories;

public class TrancaRepository : ITrancaRepository
{
    public Task<List<Tranca>> GetAll()
    {
        var json = File.ReadAllText("mock_trancas.json");
        var trancas = JsonConvert.DeserializeObject<List<Tranca>>(json);

        if (trancas != null)
        {
            return Task.FromResult(trancas);
        }

        throw new InvalidOperationException();
    }


    public Task<Tranca> Get(int idTranca)
    {
        var json = File.ReadAllText("mock_trancas.json");
        var trancas = JsonConvert.DeserializeObject<List<Tranca>>(json);

        if (trancas != null)
        {
            var tranca = trancas.FirstOrDefault(t => t.Id == idTranca);
            if (tranca != null)
            {
                return Task.FromResult(tranca);
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }

    public Task<Tranca> Create(NovaTrancaRequest novaTrancaRequest)
    {
        var json = File.ReadAllText("mock_trancas.json");
        var trancas = JsonConvert.DeserializeObject<List<Tranca>>(json);

        if (trancas != null)
        {
            var tranca = new Tranca
            {
                Id = trancas.Count + 1,
                Numero = novaTrancaRequest.Numero,
                Localizacao = novaTrancaRequest.Localizacao,
                AnoDeFabricacao = novaTrancaRequest.AnoDeFabricacao,
                Modelo = novaTrancaRequest.Modelo,
                Status = novaTrancaRequest.Status
            };

            trancas.Add(tranca);

            var updatedJsonData =
                JsonConvert.SerializeObject(trancas, Formatting.Indented);

            File.WriteAllText("mock_trancas.json", updatedJsonData);

            return Task.FromResult(tranca);
        }

        throw new InvalidOperationException();
    }


    public Task<Tranca> UpdateBicicleta(int idTranca, Tranca trancaAtualizada)
    {
        var json = File.ReadAllText("mock_trancas.json");
        var trancas = JsonConvert.DeserializeObject<List<Tranca>>(json);

        if (trancas != null)
        {
            var tranca = trancas.FirstOrDefault(t => t.Id == idTranca);
            if (tranca != null)
            {
                tranca.Numero = trancaAtualizada.Numero;
                tranca.Localizacao = trancaAtualizada.Localizacao;
                tranca.AnoDeFabricacao = trancaAtualizada.AnoDeFabricacao;
                tranca.Modelo = trancaAtualizada.Modelo;
                tranca.Status = trancaAtualizada.Status;
                return Task.FromResult(tranca);
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }

    public Task<Tranca> Delete(int idTranca)
    {
        var json = File.ReadAllText("mock_trancas.json");
        var trancas = JsonConvert.DeserializeObject<List<Tranca>>(json);

        var trancaRemovida = new Tranca();

        if (trancas != null)
            foreach (var tranca in trancas)
            {
                if (tranca.Id == idTranca)
                {
                    trancaRemovida = tranca;
                }
            }

        trancas?.Remove(trancaRemovida);

        var updatedJsonData =
            JsonConvert.SerializeObject(trancas, Formatting.Indented);

        File.WriteAllText("mock_trancas.json", updatedJsonData);

        return Task.FromResult(trancaRemovida);
    }

    public async Task<Tranca> IntegrarNaRede(int idTranca)
    {
        var json = File.ReadAllText("mock_trancas.json");
        var trancas = JsonConvert.DeserializeObject<List<Tranca>>(json);

        if (trancas != null)
        {
            var tranca = trancas.FirstOrDefault(t => t.Id == idTranca);
            if (tranca != null)
            {
                tranca.Status = TrancaStatus.LIVRE;
                return await Task.FromResult(tranca);
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }

    public async Task<Tranca> RetirarDaRede(int idTranca, RetirarDaRedeRequest retiradaTrancaRequest)
    {
        var json = File.ReadAllText("mock_trancas.json");
        var trancas = JsonConvert.DeserializeObject<List<Tranca>>(json);

        if (trancas != null)
        {
            var tranca = trancas.FirstOrDefault(t => t.Id == idTranca);
            if (tranca != null)
            {
                tranca.Status = TrancaStatus.OCUPADA;
                return await Task.FromResult(tranca);
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }

    public async Task<Tranca> AtualizarStatus(int idTranca, AcaoEnum status)
    {
        var json = File.ReadAllText("mock_trancas.json");
        var trancas = JsonConvert.DeserializeObject<List<Tranca>>(json);

        if (trancas != null)
        {
            var tranca = trancas.FirstOrDefault(t => t.Id == idTranca);
            if (tranca != null)
            {
                tranca.Status = status == AcaoEnum.TRANCAR ? TrancaStatus.OCUPADA : TrancaStatus.LIVRE;
                return await Task.FromResult(tranca);
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }

    public async Task<Tranca> TrancarTranca(int idTranca)
    {
        var json = File.ReadAllText("mock_trancas.json");
        var trancas = JsonConvert.DeserializeObject<List<Tranca>>(json);

        if (trancas != null)
        {
            var tranca = trancas.FirstOrDefault(t => t.Id == idTranca);
            if (tranca != null)
            {
                tranca.Status = TrancaStatus.OCUPADA;
                return await Task.FromResult(tranca);
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }

    public async Task<Tranca> DestrancarTranca(int idTranca)
    {
        var json = File.ReadAllText("mock_trancas.json");
        var trancas = JsonConvert.DeserializeObject<List<Tranca>>(json);

        if (trancas != null)
        {
            var tranca = trancas.FirstOrDefault(t => t.Id == idTranca);
            if (tranca != null)
            {
                tranca.Status = TrancaStatus.LIVRE;
                return await Task.FromResult(tranca);
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }
}
