using MySql.Data.MySqlClient;
using System.Data;

namespace QuickKit.Shared.Handlers;
public class DatabaseConnectionHandler
{
    private readonly string _connectionString;

    public DatabaseConnectionHandler(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection ConnectToMySQL()
    {
        return new MySqlConnection(_connectionString);
    }
}
