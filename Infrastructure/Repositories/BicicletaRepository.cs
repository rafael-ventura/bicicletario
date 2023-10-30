using BicicletarioAPI.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;
using BicicletarioAPI.Domain;
using BicicletarioAPI.Domain.Models;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
using SqlDataReader = Microsoft.Data.SqlClient.SqlDataReader;

namespace BicicletarioAPI.Infrastructure.Repositories
{
    public class BicicletaRepository : IBicicletaRepository
    {
        private readonly string _connectionString;

        public BicicletaRepository(string connectionString)
        {
            _connectionString = connectionString;
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
                                Cor = reader.GetString(3)
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
                                Cor = reader.GetString(3)
                            });
                        }
                    }
                }
            }

            return bicicletas;
        }
    }
}
