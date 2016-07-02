using System.Collections.Generic;

namespace BookLibrary.QueryModelReader
{
    public interface IQueryModelReaderSession
    {
        TModel Get<TModel, TKey>(TKey key);

        HashSet<string> GetAllItems(string key);

        List<TModel> GetByIds<TModel>(HashSet<string> ids);

    }
}