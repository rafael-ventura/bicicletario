using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;
using Microsoft.Data.SqlClient;

namespace bicicletario.Infrastructure.Repositories;

public class TotemRepository : ITotemRepository
{
    private readonly string _connectionString;
    private readonly ITrancaRepository _trancaRepository;

    public TotemRepository(string connectionString, ITrancaRepository trancaRepository)
    {
        _connectionString = connectionString;
        _trancaRepository = trancaRepository;
    }

    public async Task<IEnumerable<Totem>> ObterTodosTotens()
    {
        var totens = new List<Totem>();
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand("SELECT * FROM Totens", connection))
            {
                var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var totem = new Totem
                    {
                        Id = (int)reader["Id"],
                        Localizacao = (string)reader["Localizacao"],
                        Descricao = (string)reader["Descricao"]
                    };
                    totens.Add(totem);
                }
            }
        }

        return totens;
    }

    public async Task<Totem> ObterTotemPorId(int idTotem)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand("SELECT * FROM Totens WHERE Id = @numero", connection))
            {
                cmd.Parameters.AddWithValue("@numero", idTotem);
                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var totem = new Totem
                    {
                        Id = (int)reader["Id"],
                        Localizacao = (string)reader["Localizacao"],
                        Descricao = (string)reader["Descricao"]
                    };
                    return totem;
                }
            }
        }

        return null!;
    }

    public async Task<Totem> IncluirTotem(NovoTotemRequest novoTotemRequest)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand("INSERT INTO Totens (Localizacao, Descricao) VALUES (@toten, @status)",
                       connection))
            {
                cmd.Parameters.AddWithValue("@localizacao", novoTotemRequest.localizacao);
                cmd.Parameters.AddWithValue("@status", novoTotemRequest.descricao);

                await cmd.ExecuteNonQueryAsync();
            }
        }

        return null!;
    }

    public async Task<Totem> EditarTotem(int idTotem, Totem totemAtualizado)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand(
                       "UPDATE Totens SET Localizacao = @localizacao, Descricao = @descricao WHERE Id = @numero",
                       connection))
            {
                cmd.Parameters.AddWithValue("@localizacao", totemAtualizado.Localizacao);
                cmd.Parameters.AddWithValue("@descricao", totemAtualizado.Descricao);
                cmd.Parameters.AddWithValue("@numero", idTotem);

                await cmd.ExecuteNonQueryAsync();
            }
        }

        return null!;
    }

    public async Task<Totem> RemoverTotem(int idTotem)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand("DELETE FROM Totens WHERE Id = @numero", connection))
            {
                cmd.Parameters.AddWithValue("@numero", idTotem);

                await cmd.ExecuteNonQueryAsync();
            }
        }

        return null!;
    }

    public async Task<IEnumerable<Tranca>> ListarTrancasDoTotem(int idTotem)
    {
        var trancas = new List<Tranca>();
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand("SELECT * FROM Trancas WHERE IdTotem = @numero", connection))
            {
                cmd.Parameters.AddWithValue("@numero", idTotem);
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

    public async Task<IEnumerable<Bicicleta>> ListarBicicletasDoTotem(int idTotem)
    {
        var bicicletas = new List<Bicicleta>();
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand("SELECT * FROM Bicicletas WHERE IdTotem = @numero", connection))
            {
                cmd.Parameters.AddWithValue("@numero", idTotem);
                var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var bicicleta = new Bicicleta
                    {
                        Id = (int)reader["Id"],
                        Marca = (string)reader["Marca"],
                        Modelo = (string)reader["Modelo"],
                        Ano = (string)reader["Ano"],
                        Status = (BicicletaStatus)reader["Status"]
                    };
                    bicicletas.Add(bicicleta);
                }
            }
        }

        return bicicletas;
    }
}
