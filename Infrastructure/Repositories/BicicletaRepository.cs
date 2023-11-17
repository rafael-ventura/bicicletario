using bicicletario.Application.Exceptions;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace bicicletario.Infrastructure.Repositories
{
    public class BicicletaRepository : IBicicletaRepository
    {
        private readonly ITrancaRepository _trancaRepository;

        public BicicletaRepository(ITrancaRepository trancaRepository)
        {
            _trancaRepository = trancaRepository;
        }

        // mockar dados
        public Task<Bicicleta> Get(int id)
        {
            var jsonData = File.ReadAllText("mock_bicicletas.json");
            var bicicletas = JsonConvert.DeserializeObject<List<Bicicleta>>(jsonData);

            if (bicicletas != null)
            {
                var bicicleta = bicicletas.FirstOrDefault(b => b.Id == id);
                if (bicicleta != null)
                {
                    return Task.FromResult(bicicleta);
                }
            }
            else throw new BicicletaNaoEncontradaException(id);

            throw new InvalidOperationException();
        }

        public List<Bicicleta> GetAll()
        {
            var jsonData = File.ReadAllText("mock_bicicletas.json");
            var bicicletas = JsonConvert.DeserializeObject<List<Bicicleta>>(jsonData);

            if (bicicletas != null)
            {
                return bicicletas;
            }

            throw new InvalidOperationException();
        }

        public Task<Bicicleta> Create(NovaBicicletaRequest bicicleta)
        {
            var jsonData = File.ReadAllText("mock_bicicletas.json");
            var bicicletas = JsonConvert.DeserializeObject<List<Bicicleta>>(jsonData);

            if (bicicletas != null)
            {
                var newBicicleta = new Bicicleta
                {
                    Id = bicicletas.Count + 1,
                    Marca = bicicleta.Marca,
                    Modelo = bicicleta.Modelo,
                    Ano = bicicleta.Ano,
                    Numero = bicicleta.Numero,
                    Status = bicicleta.Status
                };

                bicicletas.Add(newBicicleta);
                var updatedJsonData =
                    JsonConvert.SerializeObject(bicicletas, (Newtonsoft.Json.Formatting)Formatting.Indented);
                File.WriteAllText("mock_bicicletas.json", updatedJsonData);
                return Task.FromResult(newBicicleta);
            }

            throw new InvalidOperationException();
        }


        public Task<Bicicleta> Update(int id, NovaBicicletaRequest bicicleta)
        {
            var jsonData = File.ReadAllText("mock_bicicletas.json");
            var bicicletas = JsonConvert.DeserializeObject<List<Bicicleta>>(jsonData);

            if (bicicletas != null)
            {
                var bike = bicicletas.FirstOrDefault(b => b.Id == id);
                if (bike != null)
                {
                    bike.Marca = bike.Marca;
                    bike.Modelo = bike.Modelo;
                    bike.Ano = bike.Ano;
                    bike.Numero = bike.Numero;
                    bike.Status = bike.Status;

                    var updatedJsonData =
                        JsonConvert.SerializeObject(bicicletas, (Newtonsoft.Json.Formatting)Formatting.Indented);
                    File.WriteAllText("mock_bicicletas.json", updatedJsonData);
                    return Task.FromResult(bike);
                }
            }
            else throw new BicicletaNaoEncontradaException(id);

            throw new InvalidOperationException();
        }


        public Task<Bicicleta> Delete(int id)
        {
            var jsonData = File.ReadAllText("mock_bicicletas.json");
            var bicicletas = JsonConvert.DeserializeObject<List<Bicicleta>>(jsonData);

            if (bicicletas != null)
            {
                var bicicleta = bicicletas.FirstOrDefault(b => b.Id == id);
                if (bicicleta != null)
                {
                    bicicletas.Remove(bicicleta);
                    var updatedJsonData =
                        JsonConvert.SerializeObject(bicicletas, (Newtonsoft.Json.Formatting)Formatting.Indented);
                    File.WriteAllText("mock_bicicletas.json", updatedJsonData);
                    return Task.FromResult(bicicleta);
                }
            }
            else throw new BicicletaNaoEncontradaException(id);

            throw new InvalidOperationException();
        }

        public async Task<Bicicleta> IntegrarNaRede(int idTotem, int idBicicleta, int idFuncionario)
        {
            var bicicleta = await Get(idTotem);
            var tranca = await _trancaRepository.Get(idBicicleta);

            if (bicicleta == null)
                throw new BicicletaNaoEncontradaException(idBicicleta);
            if (tranca == null)
                throw new TrancaNaoEncontradaException(idBicicleta);
            if (bicicleta.Status != BicicletaStatus.EM_USO)
                throw new BicicletaNaoDisponivelException(idBicicleta);

            if (tranca.Status != TrancaStatus.OCUPADA)
                throw new TrancaNaoDisponivelException(idTotem);

            tranca.Status = TrancaStatus.LIVRE;

            await AtualizarStatus(bicicleta.Id, BicicletaStatus.DISPONIVEL);
            return bicicleta;
        }

        public async Task<Bicicleta> RetirarDaRede(int idTranca, int idBicicleta, int idFuncionario,
            string statusAcaoReparador)
        {
            var bicicleta = await Get(idBicicleta);
            var tranca = await _trancaRepository.Get(idTranca);

            if (bicicleta == null)
                throw new BicicletaNaoEncontradaException(idBicicleta);
            if (tranca == null)
                throw new TrancaNaoEncontradaException(idTranca);
            if (bicicleta.Status != BicicletaStatus.DISPONIVEL)
                throw new BicicletaNaoDisponivelException(idBicicleta);

            if (tranca.Status != TrancaStatus.LIVRE)
                throw new TrancaNaoDisponivelException(idTranca);

            tranca.Status = TrancaStatus.OCUPADA;

            await AtualizarStatus(bicicleta.Id, BicicletaStatus.EM_USO);
            return bicicleta;
        }

        public async Task<Bicicleta> AtualizarStatus(int id, BicicletaStatus status)
        {
            // Ler o arquivo JSON
            var jsonData = await File.ReadAllTextAsync("mock_bicicletas.json");
            var bicicletas = JsonConvert.DeserializeObject<List<Bicicleta>>(jsonData);

            // Encontrar a bicicleta pelo ID e atualizar o status
            if (bicicletas != null)
            {
                var bicicleta = bicicletas.FirstOrDefault(b => b.Id == id);
                if (bicicleta != null)
                {
                    bicicleta.Status = status;

                    // Salvar as alterações de volta no arquivo JSON
                    var updatedJsonData =
                        JsonConvert.SerializeObject(bicicletas, (Newtonsoft.Json.Formatting)Formatting.Indented);
                    await File.WriteAllTextAsync("mock_bicicletas.json", updatedJsonData);

                    return bicicleta;
                }
            }
            else throw new BicicletaNaoEncontradaException(id);

            throw new InvalidOperationException();
        }


        public async Task<Bicicleta> ObterBicicletaPorNumero(int numero)
        {
            var jsonData = await File.ReadAllTextAsync("mock_bicicletas.json");
            var bicicletas = JsonConvert.DeserializeObject<List<Bicicleta>>(jsonData);

            if (bicicletas != null)
            {
                var bicicleta = bicicletas.FirstOrDefault(b => b.Numero == numero);
                if (bicicleta != null)
                {
                    return bicicleta;
                }
            }
            else throw new BicicletaNaoEncontradaException(numero);

            throw new InvalidOperationException();
        }
    }
}
