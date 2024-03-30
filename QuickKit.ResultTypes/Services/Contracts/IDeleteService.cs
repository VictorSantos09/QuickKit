namespace QuickKit.ResultTypes.Services.Contracts;

public interface IDeleteService<TKey>
    where TKey : IConvertible
{
    public Task<Final> DeleteAsync(TKey id);
}