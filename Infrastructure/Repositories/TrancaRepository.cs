using bicicletario.Application.Exceptions;
using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;
using Microsoft.Data.SqlClient;

namespace bicicletario.Infrastructure.Repositories;

public class TrancaRepository : ITrancaRepository
{
    private readonly string _connectionString;

    public TrancaRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<Tranca>> GetAll()
    {
        var trancas = new List<Tranca>();
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand("SELECT * FROM Trancas", connection))
            {
                var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var tranca = new Tranca
                    {
                        Id = (int)reader["Id"],
                        Numero = (int)reader["Numero"],
                        Localizacao = (string)reader["Localizacao"],
                        AnoDeFabricacao = (string)reader["AnoDeFabricacao"],
                        Modelo = (string)reader["Modelo"],
                        Status = (TrancaStatus)reader["Status"]
                    };
                    trancas.Add(tranca);
                }
            }
        }

        return trancas;
    }


    public async Task<Tranca> Get(int idTranca)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand("SELECT * FROM Trancas WHERE Id = @numero", connection))
            {
                cmd.Parameters.AddWithValue("@numero", idTranca);
                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var tranca = new Tranca
                    {
                        Id = (int)reader["Id"],
                        Numero = (int)reader["Numero"],
                        Localizacao = (string)reader["Localizacao"],
                        AnoDeFabricacao = (string)reader["AnoDeFabricacao"],
                        Modelo = (string)reader["Modelo"],
                        Status = (TrancaStatus)reader["Status"]
                    };
                    return tranca;
                }
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }

    public async Task<Tranca> Create(NovaTrancaRequest novaTrancaRequest)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand(
                       "INSERT INTO Trancas (Numero, Localizacao, AnoDeFabricacao, Modelo, Status) VALUES (@numero, @localizacao, @ano, @modelo, @status)",
                       connection))
            {
                cmd.Parameters.AddWithValue("@numero", novaTrancaRequest.numero);
                cmd.Parameters.AddWithValue("@localizacao", novaTrancaRequest.localizacao);
                cmd.Parameters.AddWithValue("@ano", novaTrancaRequest.anoDeFabricacao);
                cmd.Parameters.AddWithValue("@modelo", novaTrancaRequest.modelo);
                cmd.Parameters.AddWithValue("@status", novaTrancaRequest.status);
                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var tranca = new Tranca
                    {
                        Id = (int)reader["Id"],
                        Numero = (int)reader["Numero"],
                        Localizacao = (string)reader["Localizacao"],
                        AnoDeFabricacao = (string)reader["AnoDeFabricacao"],
                        Modelo = (string)reader["Modelo"],
                        Status = (TrancaStatus)reader["Status"]
                    };
                    return tranca;
                }
            }
        }

        throw new DadosInvalidosException();
    }

    public async Task<Tranca> UpdateBicicleta(int idTranca, Tranca trancaAtualizada)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand(
                       "UPDATE Trancas SET Numero = @numero, Localizacao = @localizacao, AnoDeFabricacao = @ano, Modelo = @modelo, Status = @status WHERE Id = @idTranca",
                       connection))
            {
                cmd.Parameters.AddWithValue("@numero", trancaAtualizada.Numero);
                cmd.Parameters.AddWithValue("@localizacao", trancaAtualizada.Localizacao);
                cmd.Parameters.AddWithValue("@ano", trancaAtualizada.AnoDeFabricacao);
                cmd.Parameters.AddWithValue("@modelo", trancaAtualizada.Modelo);
                cmd.Parameters.AddWithValue("@status", trancaAtualizada.Status);
                cmd.Parameters.AddWithValue("@idTranca", idTranca);
                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var tranca = new Tranca
                    {
                        Id = (int)reader["Id"],
                        Numero = (int)reader["Numero"],
                        Localizacao = (string)reader["Localizacao"],
                        AnoDeFabricacao = (string)reader["AnoDeFabricacao"],
                        Modelo = (string)reader["Modelo"],
                        Status = (TrancaStatus)reader["Status"]
                    };
                    return tranca;
                }
            }

            throw new Exception();
        }
    }

    public async Task<Tranca> Delete(int idTranca)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand("DELETE FROM Trancas WHERE Id = @numero", connection))
            {
                cmd.Parameters.AddWithValue("@numero", idTranca);

                var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var tranca = new Tranca
                    {
                        Id = (int)reader["Id"],
                        Numero = (int)reader["Numero"],
                        Localizacao = (string)reader["Localizacao"],
                        AnoDeFabricacao = (string)reader["AnoDeFabricacao"],
                        Modelo = (string)reader["Modelo"],
                        Status = (TrancaStatus)reader["Status"]
                    };
                    return tranca;
                }
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }

    public async Task<Tranca> IntegrarNaRede(int idTranca)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand(
                       "UPDATE Trancas SET Status = @status WHERE Id = @idTranca", connection))
            {
                cmd.Parameters.AddWithValue("@status", TrancaStatus.NOVA);
                cmd.Parameters.AddWithValue("@idTranca", idTranca);
                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var tranca = new Tranca
                    {
                        Id = (int)reader["Id"],
                        Numero = (int)reader["Numero"],
                        Localizacao = (string)reader["Localizacao"],
                        AnoDeFabricacao = (string)reader["AnoDeFabricacao"],
                        Modelo = (string)reader["Modelo"],
                        Status = (TrancaStatus)reader["Status"]
                    };
                    return tranca;
                }
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }

    public async Task<Tranca> RetirarDaRede(int idTranca, RetirarDaRedeRequest retiradaTrancaRequest)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand(
                       "UPDATE Trancas SET Status = @status WHERE Id = @idTranca", connection))
            {
                cmd.Parameters.AddWithValue("@status", TrancaStatus.APOSENTADA);
                cmd.Parameters.AddWithValue("@idTranca", idTranca);
                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var tranca = new Tranca
                    {
                        Id = (int)reader["Id"],
                        Numero = (int)reader["Numero"],
                        Localizacao = (string)reader["Localizacao"],
                        AnoDeFabricacao = (string)reader["AnoDeFabricacao"],
                        Modelo = (string)reader["Modelo"],
                        Status = (TrancaStatus)reader["Status"]
                    };
                    return tranca;
                }
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }

    public async Task<Tranca> AtualizarStatus(int idTranca, AcaoEnum status)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand(
                       "UPDATE Trancas SET Status = @status WHERE Id = @idTranca", connection))
            {
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@idTranca", idTranca);
                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var tranca = new Tranca
                    {
                        Id = (int)reader["Id"],
                        Numero = (int)reader["Numero"],
                        Localizacao = (string)reader["Localizacao"],
                        AnoDeFabricacao = (string)reader["AnoDeFabricacao"],
                        Modelo = (string)reader["Modelo"],
                        Status = (TrancaStatus)reader["Status"]
                    };
                    return tranca;
                }
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }

    public async Task<Tranca> TrancarTranca(int idTranca)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand(
                       "UPDATE Trancas SET Status = @status WHERE Id = @idTranca", connection))
            {
                cmd.Parameters.AddWithValue("@status", TrancaStatus.OCUPADA);
                cmd.Parameters.AddWithValue("@idTranca", idTranca);
                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var tranca = new Tranca
                    {
                        Id = (int)reader["Id"],
                        Numero = (int)reader["Numero"],
                        Localizacao = (string)reader["Localizacao"],
                        AnoDeFabricacao = (string)reader["AnoDeFabricacao"],
                        Modelo = (string)reader["Modelo"],
                        Status = (TrancaStatus)reader["Status"]
                    };
                    return tranca;
                }
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }

    public async Task<Tranca> DestrancarTranca(int idTranca)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand(
                       "UPDATE Trancas SET Status = @status WHERE Id = @idTranca", connection))
            {
                cmd.Parameters.AddWithValue("@status", TrancaStatus.LIVRE);
                cmd.Parameters.AddWithValue("@idTranca", idTranca);
                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var tranca = new Tranca
                    {
                        Id = (int)reader["Id"],
                        Numero = (int)reader["Numero"],
                        Localizacao = (string)reader["Localizacao"],
                        AnoDeFabricacao = (string)reader["AnoDeFabricacao"],
                        Modelo = (string)reader["Modelo"],
                        Status = (TrancaStatus)reader["Status"]
                    };
                    return tranca;
                }
            }
        }

        throw new TrancaNaoEncontradaException(idTranca);
    }
}
