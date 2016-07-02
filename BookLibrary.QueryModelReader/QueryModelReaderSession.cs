using System.Collections.Generic;
using System.Linq;
using ServiceStack.Redis;

namespace BookLibrary.QueryModelReader
{
    public class QueryModelReaderSession:IQueryModelReaderSession
    {
        public TModel Get<TModel, TKey>(TKey key)
        {
            using (IRedisClient client = new RedisClient())
            {
                var modelClient = client.As<TModel>();
                return modelClient.GetById(key);
            }
        }

        public HashSet<string> GetAllItems(string key)
        {
            using (IRedisClient client = new RedisClient())
            {
                return client.GetAllItemsFromSet(key);
            }
        }

        public List<TModel> GetByIds<TModel>(HashSet<string> ids)
        {
            using (IRedisClient client = new RedisClient())
            {
                var modelClient = client.As<TModel>();
                return modelClient.GetByIds(ids).ToList();
            }
        }
    }
}