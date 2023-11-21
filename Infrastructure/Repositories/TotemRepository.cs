using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;
using Newtonsoft.Json;

namespace bicicletario.Infrastructure.Repositories;

public class TotemRepository : ITotemRepository
{
    private readonly ITrancaRepository _trancaRepository;

    public TotemRepository(ITrancaRepository trancaRepository)
    {
        _trancaRepository = trancaRepository;
    }

    public Task<List<Totem>> ObterTodosTotens()
    {
        var jsonData = File.ReadAllText("mock_totens.json");
        var totens = JsonConvert.DeserializeObject<List<Totem>>(jsonData);

        if (totens != null)
        {
            return Task.FromResult(totens);
        }

        throw new InvalidOperationException();
    }

    public Task<Totem> ObterTotemPorId(int idTotem)
    {
        var json = File.ReadAllText("mock_totens.json");
        var totens = JsonConvert.DeserializeObject<List<Totem>>(json);

        var totem = new Totem();

        if (totens != null)
            foreach (var t in totens)
            {
                if (t.Id == idTotem)
                {
                    totem = t;
                }
            }

        return Task.FromResult(totem);
    }

    public Task<Totem> IncluirTotem(NovoTotemRequest novoTotemRequest)
    {
        var totem = new Totem
        {
            Localizacao = novoTotemRequest.Localizacao,
            Descricao = novoTotemRequest.Descricao
        };

        var json = File.ReadAllText("mock_totens.json");

        var totens = JsonConvert.DeserializeObject<List<Totem>>(json);

        totens?.Add(totem);

        var updatedJsonData =
            JsonConvert.SerializeObject(totens, Formatting.Indented);

        File.WriteAllText("mock_totens.json", updatedJsonData);

        return Task.FromResult(totem);
    }

    public Task<Totem> EditarTotem(int idTotem, Totem totemAtualizado)
    {
        var json = File.ReadAllText("mock_totens.json");

        var totens = JsonConvert.DeserializeObject<List<Totem>>(json);

        var totemEditado = new Totem();

        if (totens != null)
            foreach (var totem in totens)
            {
                if (totem.Id == idTotem)
                {
                    totemEditado = totem;
                }
            }

        totens?.Remove(totemEditado);

        var updatedJsonData =
            JsonConvert.SerializeObject(totens, Formatting.Indented);

        File.WriteAllText("mock_totens.json", updatedJsonData);

        return Task.FromResult(totemAtualizado);
    }

    public Task<Totem> RemoverTotem(int idTotem)
    {
        var json = File.ReadAllText("mock_totens.json");
        var totens = JsonConvert.DeserializeObject<List<Totem>>(json);

        var totemRemovido = new Totem();

        if (totens != null)
            foreach (var totem in totens)
            {
                if (totem.Id == idTotem)
                {
                    totemRemovido = totem;
                }
            }

        totens?.Remove(totemRemovido);

        var updatedJsonData =
            JsonConvert.SerializeObject(totens, Formatting.Indented);

        File.WriteAllText("mock_totens.json", updatedJsonData);

        return Task.FromResult(totemRemovido);
    }

    public Task<List<Tranca>> ListarTrancasDoTotem(int idTotem)
    {
        var json = File.ReadAllText("mock_trancas.json");
        var trancas = JsonConvert.DeserializeObject<List<Tranca>>(json);

        var trancasDoTotem = new List<Tranca>();

        if (trancas != null)
            foreach (var tranca in trancas)
            {
                if (tranca.Id == idTotem)
                {
                    trancasDoTotem.Add(tranca);
                }
            }

        return Task.FromResult(trancasDoTotem);
    }

    public async Task<List<Bicicleta>> ListarBicicletasDoTotem(int idTotem)
    {
        var json = File.ReadAllText("mock_bicicletas.json");
        var bicicletas = JsonConvert.DeserializeObject<List<Bicicleta>>(json);

        var trancas = await _trancaRepository.GetAll();

        var bicicletasDoTotem = new List<Bicicleta>();

        if (bicicletas != null)
            foreach (var bicicleta in bicicletas)
            {
                var enumerable = trancas.ToList();
                foreach (var tranca in enumerable)
                {
                    if (bicicleta.Id == tranca.BicicletaId && tranca.BicicletaId == idTotem)
                    {
                        bicicletasDoTotem.Add(bicicleta);
                    }
                }
            }

        return bicicletasDoTotem;
    }
}
