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
        private readonly ITotemRepository _totemRepository;

        public BicicletaRepository(ITrancaRepository trancaRepository, ITotemRepository totemRepository)
        {
            _trancaRepository = trancaRepository;
            _totemRepository = totemRepository;
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

            throw new BicicletaNaoEncontradaException();
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

        public async Task<Bicicleta> IntegrarNaRede(IntegrarNaRedeRequest request)
        {
            var bicicleta = await Get(request.IdBicicleta);
            var tranca = await _trancaRepository.Get(request.IdTranca);


            if (bicicleta == null)
                throw new BicicletaNaoEncontradaException(request.IdBicicleta);
            if (tranca == null)
                throw new TrancaNaoEncontradaException(request.IdTranca);

            if (bicicleta.Status == BicicletaStatus.EmUso)
            {
                // _devolucaoRepository.Devolver(request.IdBicicleta);
            }

            await _trancaRepository.IntegrarNaRede(request.IdTranca);

            await _trancaRepository.TrancarTranca(tranca.Id);

            await AtualizarStatus(bicicleta.Id, BicicletaStatus.Disponivel);

            // funcionario = _funcionarioRepository.getFuncionario(request.IdFuncionario);
            // _emailRepository.enviarEmail(funcioanrio.Email, "Integracao da Bicicleta {request.IdBicicleta}", "Bicicleta {request.IdBicicleta} integrada na rede, na tranca {request.IdTranca}.");
            return bicicleta;
        }

        public async Task<Bicicleta> RetirarDaRede(RetirarDaRedeRequest request)
        {
            var bicicleta = await Get(request.IdBicicleta);
            var tranca = await _trancaRepository.Get(request.IdTranca);

            if (request.StatusAcaoReparador == "Aposentadoria")
            {
                if (tranca == null)
                    throw new TrancaNaoEncontradaException(request.IdTranca);

                if (bicicleta.Status == BicicletaStatus.Disponivel)
                    throw new BicicletaNaoDisponivelException(request.IdBicicleta);


                if (tranca.Status == TrancaStatus.Livre)
                {
                    await RetirarDaRede(request);
                    throw new TrancaNaoDisponivelException(request.IdTranca);
                }

                await _trancaRepository.DestrancarTranca(tranca.Id);

                await _trancaRepository.RetirarDaRede(tranca.Id, request);

                await AtualizarStatus(bicicleta.Id, BicicletaStatus.Aposentada);

                // funcionario = _funcionarioRepository.getFuncionario(request.IdFuncionario);
                // _emailRepository.enviarEmail(funcioanrio.Email, "Retirada da Bicicleta {request.IdBicicleta}", "Bicicleta {request.IdBicicleta} retirada da rede, na tranca {request.IdTranca}.");
            }

            if (request.StatusAcaoReparador == "Reparo")
            {
                if (tranca == null)
                    throw new TrancaNaoEncontradaException(request.IdTranca);

                await _trancaRepository.DestrancarTranca(tranca.Id);

                await _trancaRepository.RetirarDaRede(tranca.Id, request);

                await AtualizarStatus(bicicleta.Id, BicicletaStatus.EmReparo);

                // funcionario = _funcionarioRepository.getFuncionario(request.IdFuncionario);
                // _emailRepository.enviarEmail(funcioanrio.Email, "Retirada da Bicicleta {request.IdBicicleta}", "Bicicleta {request.IdBicicleta} retirada da rede, na tranca {request.IdTranca}.");
            }


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
