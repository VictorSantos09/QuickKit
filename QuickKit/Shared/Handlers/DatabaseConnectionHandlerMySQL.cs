using MySql.Data.MySqlClient;
using System.Data;

namespace QuickKit.Shared.Handlers;

/// <summary>
/// Represents a database connection handler for MySQL.
/// </summary>
internal class DatabaseConnectionHandlerMySQL : IDatabaseConnectionHandler
{
    private readonly string _connectionString;

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseConnectionHandlerMySQL"/> class with the specified connection string.
    /// </summary>
    /// <param name="connectionString">The connection string to be used for connecting to the database.</param>
    public DatabaseConnectionHandlerMySQL(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Connects to the database using the specified connection string.
    /// </summary>
    /// <returns>An instance of <see cref="IDbConnection"/> representing the database connection.</returns>
    public virtual IDbConnection Connect()
    {
        return new MySqlConnection(_connectionString);
    }
}
