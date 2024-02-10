namespace QuickKit.Entities;

public interface IEntityBase {}

public interface IEntity : IEntityBase
{
    public int Id { get; set; }
}

public interface IEntity<TKey> : IEntityBase where TKey : struct
{
    public TKey Id { get; set; }
}

public interface IEntity<TEntity, TSnapshot> : IEntity where TEntity : IEntity
{
    public abstract static TEntity FromSnapshot(TSnapshot snapshot);
    TSnapshot ToSnapshot();
}

public interface IEntity<TEntity, TSnapshot, Tkey> : IEntity where TEntity : IEntity<Tkey> where Tkey : struct
{
    public abstract static TEntity FromSnapshot(TSnapshot snapshot);
    TSnapshot ToSnapshot();
}