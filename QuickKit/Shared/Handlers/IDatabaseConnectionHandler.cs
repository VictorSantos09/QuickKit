using System.Data;

namespace QuickKit.Shared.Handlers;

/// <summary>
/// Represents a handler for establishing database connections.
/// </summary>
public interface IDatabaseConnectionHandler
{
    /// <summary>
    /// Connects to the database and returns a database connection object.
    /// </summary>
    /// <returns>The database connection object.</returns>
    abstract IDbConnection Connect();
}