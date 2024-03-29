namespace QuickKit.ResultTypes.Services.Contracts;

public interface IDeleteValueObjectService<TKey>
    where TKey : IConvertible
{
    public Task<Final> DeleteAsync(TKey id);
}