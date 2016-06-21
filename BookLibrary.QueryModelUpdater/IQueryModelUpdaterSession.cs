namespace BookLibrary.QueryModelUpdater
{
    public interface IQueryModelUpdaterSession
    {
        TModel Get<TModel, TKey>(TKey key);

        void Save<TModel>(TModel model);
    }
}