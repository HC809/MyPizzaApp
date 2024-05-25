using AlbaPizzaApp.Infraestructure.Abstractions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AlbaPizzaApp.Infraestructure.Data;
internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();

        return connection;
    }
}
