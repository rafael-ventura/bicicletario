using bicicletario.Domain.dtos;
using bicicletario.Domain.Interfaces;
using bicicletario.Domain.Models;
using Microsoft.Data.SqlClient;

namespace bicicletario.Infrastructure.Repositories;

public class TotemRepository
{
    private readonly string _connectionString;
    private readonly ITrancaRepository _trancaRepository;

    public TotemRepository(string connectionString, ITrancaRepository trancaRepository)
    {
        _connectionString = connectionString;
        _trancaRepository = trancaRepository;
    }

    public async Task<Totem> IncluirTotem(TotemRequest totem)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var cmd = new SqlCommand("INSERT INTO Totens (Localizacao, Descricao) VALUES (@toten, @status)", connection))
            {
                cmd.Parameters.AddWithValue("@localizacao", totem.localizacao);
                cmd.Parameters.AddWithValue("@status", totem.descricao);

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
            using (var cmd = new SqlCommand("UPDATE Totens SET Localizacao = @localizacao, Descricao = @descricao WHERE Id = @idTotem", connection))
            {
                cmd.Parameters.AddWithValue("@localizacao", totemAtualizado.Localizacao);
                cmd.Parameters.AddWithValue("@descricao", totemAtualizado.Descricao);
                cmd.Parameters.AddWithValue("@idTotem", idTotem);

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
            using (var cmd = new SqlCommand("DELETE FROM Totens WHERE Id = @idTotem", connection))
            {
                cmd.Parameters.AddWithValue("@idTotem", idTotem);

                await cmd.ExecuteNonQueryAsync();
            }
        }

        return null!;
    }
    
    

    
    
}
