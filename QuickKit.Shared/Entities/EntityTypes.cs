namespace QuickKit.Shared.Entities;

#region Default Internal
/// <summary>
/// Interface base for all entities used in the application.
/// </summary>
/// <remarks>-- DO NOT USE DIRECTLY ON ENTITIES --
/// <para>Instead implements from <see cref="IEntity{TKey}"/> or <see cref="IEntity{TEntity, TSnapshot, TKey}"/></para>
/// <para>It is only used to identity entities, you can use it to do the same.</para>
/// </remarks>
public interface IEntity { }
#endregion

#region Default with Key
/// <summary>
/// Represents an entity with a specified key.
/// </summary>
/// <typeparam name="TKey">The type of the entity's key.</typeparam>
public interface IEntity<TKey> : IEntity
    where TKey : IConvertible
{
    /// <summary>
    /// Gets or sets the entity's key.
    /// </summary>
    TKey Id { get; set; }
}
#endregion

#region Default with Key and Snapshot
/// <summary>
/// Represents an entity with a specified key, along with methods to convert to and from a snapshot.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TSnapshot">The type of the snapshot.</typeparam>
/// <typeparam name="TKey">The type of the entity's key.</typeparam>
public interface IEntity<TEntity, TSnapshot, TKey> : IEntity<TKey>
    where TEntity : IEntity<TKey>
    where TSnapshot : class
    where TKey : IConvertible
{
    /// <summary>
    /// Converts a snapshot to an entity.
    /// </summary>
    /// <param name="snapshot">The snapshot to convert.</param>
    /// <returns>The converted entity.</returns>
    public static abstract TEntity FromSnapshot(TSnapshot snapshot);

    /// <summary>
    /// Converts the entity to a snapshot.
    /// </summary>
    /// <returns>The snapshot representation of the entity.</returns>
    TSnapshot ToSnapshot();
}
#endregion