using System.Collections.Generic;

namespace BookLibrary.QueryModelUpdater
{
    public interface IQueryModelUpdaterSession
    {
        void Save<TModel>(TModel model);

        void Delete<TModel,TKey>(TKey key);

        void AddItemToSet(string key, string item);

    }
}