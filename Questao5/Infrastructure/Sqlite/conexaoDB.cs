using Microsoft.Data.Sqlite;
using System.Data;

namespace Questao5.Infrastructure.Sqlite
{
    public class conexaoDB
    {
        private readonly string _connectionString;

        public conexaoDB(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
