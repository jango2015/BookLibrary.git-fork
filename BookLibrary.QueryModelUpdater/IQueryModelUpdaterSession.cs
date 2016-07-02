using System.Collections.Generic;

namespace BookLibrary.QueryModelUpdater
{
    public interface IQueryModelUpdaterSession
    {
        TModel Get<TModel, TKey>(TKey key);

        void Save<TModel>(TModel model);

        void Delete<TModel,TKey>(TKey key);

        void AddToList(string key, string item);

        List<string> GetAllItem(string key);
    }
}