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
                                Ano = reader.GetInt32(3),
                                Numero = reader.GetInt32(4),
                                Status = (BicicletaStatus) reader.GetInt32(5)
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
                                Ano = reader.GetInt32(3),
                                Numero = reader.GetInt32(4),
                                Status = (BicicletaStatus) reader.GetInt32(5)
                            });
                        }
                    }
                }
            }

            return bicicletas;
        }
        
        public async Task<Bicicleta> Create(Bicicleta bicicleta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand(
                    "INSERT INTO Bicicletas (Modelo, Marca, Ano, Numero, Status) VALUES (@modelo, @marca, @ano, @numero, @status); SELECT SCOPE_IDENTITY()",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@modelo", bicicleta.Modelo);
                    cmd.Parameters.AddWithValue("@marca", bicicleta.Marca);
                    cmd.Parameters.AddWithValue("@ano", bicicleta.Ano);
                    cmd.Parameters.AddWithValue("@numero", bicicleta.Numero);
                    cmd.Parameters.AddWithValue("@status", bicicleta.Status);

                    bicicleta.Id = (int) (decimal) (await cmd.ExecuteScalarAsync() ?? 0);
                }
            }

            return bicicleta;
        }
        
        public async Task<Bicicleta> Update(int id, Bicicleta bicicleta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand(
                    "UPDATE Bicicletas SET Modelo = @modelo, Marca = @marca, Ano = @ano, Numero = @numero, Status = @status WHERE Id = @id",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@id", bicicleta.Id);
                    cmd.Parameters.AddWithValue("@modelo", bicicleta.Modelo);
                    cmd.Parameters.AddWithValue("@marca", bicicleta.Marca);
                    cmd.Parameters.AddWithValue("@ano", bicicleta.Ano);
                    cmd.Parameters.AddWithValue("@numero", bicicleta.Numero);
                    cmd.Parameters.AddWithValue("@status", bicicleta.Status);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return bicicleta;
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
        
        public async Task<Bicicleta> IntegrarNaRede(Bicicleta bicicleta)
        {
            // IMPLEMENTE UM CODIGO QUE SIMULA A INTEGRACAO DE UMA BICICLETA NA REDE DE TOKENS
            var tranca = await _trancaRepository.Get(bicicleta.Id);
            
        }
        
        public async Task<Bicicleta> RetirarDaRede(int idTranca, int idBicicleta, int idFuncionario,
            BicicletaStatus statusAcaoReparador)
        {
            // IMPLEMENTE UM CODIGO QUE SIMULA A RETIRADA DE UMA BICICLETA NA REDE DE TOKENS E ATUALIZA O STATUS DELA
            
            
        }
        
        public async Task<Bicicleta> AtualizarStatus(int id, BicicletaStatus status)
        {
            var bicicleta = await Get(id);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand(
                    "UPDATE Bicicletas SET Status = @status WHERE Id = @id",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@status", status);

                    await cmd.ExecuteNonQueryAsync();
                }
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
                                Ano = reader.GetInt32(3),
                                Numero = reader.GetInt32(4),
                                Status = (BicicletaStatus) reader.GetInt32(5)
                            };
                        }
                    }
                }
            }

            return null!;
        }
        
    }
}
