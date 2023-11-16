﻿using bicicletario.Application.Exceptions;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;

namespace bicicletario.Infrastructure.Repositories
{
    public class BicicletaRepository : IBicicletaRepository
    {
        private readonly string _connectionString;
        private readonly ITrancaRepository _trancaRepository;

        public BicicletaRepository(string connectionString, ITrancaRepository trancaRepository)
        {
            _connectionString = connectionString;
            _trancaRepository = trancaRepository;
        }

        public async Task<Bicicleta> Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("SELECT * FROM Bicicletas WHERE Id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Bicicleta
                            {
                                Id = reader.GetInt32(0),
                                Modelo = reader.GetString(1),
                                Marca = reader.GetString(2),
                                Ano = reader.GetInt32(3).ToString(),
                                Numero = reader.GetInt32(4),
                                Status = (BicicletaStatus)reader.GetInt32(5)
                            };
                        }
                    }
                }
            }

            return null!;
        }

        public IEnumerable<Bicicleta> GetAll()
        {
            var bicicletas = new List<Bicicleta>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand("SELECT * FROM Bicicletas", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bicicletas.Add(new Bicicleta
                            {
                                Id = reader.GetInt32(0),
                                Modelo = reader.GetString(1),
                                Marca = reader.GetString(2),
                                Ano = reader.GetInt32(3).ToString(),
                                Numero = reader.GetInt32(4),
                                Status = (BicicletaStatus)reader.GetInt32(5)
                            });
                        }
                    }
                }
            }

            return bicicletas;
        }

        public async Task<Bicicleta> Create(NovaBicicletaRequest bicicleta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand(
                           "INSERT INTO Bicicletas (Marca, Modelo, Ano, Numero, Status) VALUES (@marca, @modelo, @ano, @numero, @status); SELECT SCOPE_IDENTITY()",
                           connection))
                {
                    cmd.Parameters.AddWithValue("@marca", bicicleta.marca);
                    cmd.Parameters.AddWithValue("@modelo", bicicleta.modelo);
                    cmd.Parameters.AddWithValue("@ano", bicicleta.ano);
                    cmd.Parameters.AddWithValue("@numero", bicicleta.numero);
                    cmd.Parameters.AddWithValue("@status", bicicleta.status);

                    var id = await cmd.ExecuteScalarAsync();
                    return new Bicicleta
                    {
                        Id = (int)(id ?? 0),
                        Marca = bicicleta.marca,
                        Modelo = bicicleta.modelo,
                        Ano = bicicleta.ano,
                        Numero = bicicleta.numero,
                        Status = bicicleta.status
                    };
                }
            }
        }

        public async Task<Bicicleta> Update(int id, NovaBicicletaRequest bicicleta)
        {
            var bicicletaAtual = await Get(id);
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand(
                           "UPDATE Bicicletas SET Marca = @marca, Modelo = @modelo, Ano = @ano, Numero = @numero, Status = @status WHERE Id = @id",
                           connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@marca", bicicleta.marca);
                    cmd.Parameters.AddWithValue("@modelo", bicicleta.modelo);
                    cmd.Parameters.AddWithValue("@ano", bicicleta.ano);
                    cmd.Parameters.AddWithValue("@numero", bicicleta.numero);
                    cmd.Parameters.AddWithValue("@status", bicicleta.status);


                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return bicicletaAtual;
        }

        public async Task<Bicicleta> Delete(int id)
        {
            var bicicleta = await Get(id);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("DELETE FROM Bicicletas WHERE Id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return bicicleta;
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

            bicicleta.Status = BicicletaStatus.DISPONIVEL;
            tranca.Status = TrancaStatus.LIVRE;

            // await Update(bicicleta.Id, bicicleta);

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
                throw new BicicletaNaoDisponivelException(idTranca);

            if (tranca.Status != TrancaStatus.LIVRE)
                throw new TrancaNaoDisponivelException(idBicicleta);

            bicicleta.Status = BicicletaStatus.EM_USO;
            tranca.Status = TrancaStatus.OCUPADA;

            /*await Update(bicicleta.Id, bicicleta);*/
            await _trancaRepository.UpdateBicicleta(tranca.Id, tranca);

            return bicicleta;
        }

        public async Task<Bicicleta> AtualizarStatus(int id, BicicletaStatus status)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var bicicleta = await Get(id);

                if (bicicleta == null)
                    throw new BicicletaNaoEncontradaException(id);

                bicicleta.Status = status;

                /*await Update(bicicleta.Id, bicicleta);*/

                return bicicleta;
            }
        }


        public async Task<Bicicleta> ObterBicicletaPorNumero(int numero)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("SELECT * FROM Bicicletas WHERE Numero = @numero", connection))
                {
                    cmd.Parameters.AddWithValue("@numero", numero);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Bicicleta
                            {
                                Id = reader.GetInt32(0),
                                Modelo = reader.GetString(1),
                                Marca = reader.GetString(2),
                                Ano = reader.GetInt32(3).ToString(),
                                Numero = reader.GetInt32(4),
                                Status = (BicicletaStatus)reader.GetInt32(5)
                            };
                        }
                    }
                }
            }

            return null!;
        }
    }
}