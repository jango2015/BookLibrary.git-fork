namespace BookLibrary.QueryModelReader
{
    public interface IQueryModelReaderSession
    {
        TModel Get<TModel, TKey>(TKey key);
    }
}