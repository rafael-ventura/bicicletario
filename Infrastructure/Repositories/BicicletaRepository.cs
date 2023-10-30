using System.Data;
using System.Data.SqlClient;
using BicicletarioAPI.Domain;
using BicicletarioAPI.Domain.Interfaces;

namespace BicicletarioAPI.Infrastructure.Repositories;

public class BicicletaRepository : IBicicletaRepository
{
    private readonly DatabaseConnection _databaseConnection;

    public BicicletaRepository(DatabaseConnection databaseConnection)
    {
        _databaseConnection = databaseConnection;
    }

    public Bicicleta Get(int id)
    {
        Bicicleta bicicleta = null!;

        using (var dbConnection = _databaseConnection.CreateConnection())
        {
            dbConnection.Open();

            using (var dbCommand = dbConnection.CreateCommand())
            {
                dbCommand.CommandText = "SELECT Id, Marca, Modelo, Cor FROM Bicicletas WHERE Id = @Id";
                var parameter = new SqlParameter("@Id", id);
                dbCommand.Parameters.Add(parameter);

                using (var reader = dbCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        bicicleta = new Bicicleta
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Marca = reader.GetString(reader.GetOrdinal("Marca")),
                            Modelo = reader.GetString(reader.GetOrdinal("Modelo")),
                            Cor = reader.GetString(reader.GetOrdinal("Cor"))
                        };
                    }
                }
            }
        }

        return bicicleta;
    }
}
