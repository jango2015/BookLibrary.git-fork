using System.Collections.Generic;
using ServiceStack;
using ServiceStack.Redis;

namespace BookLibrary.QueryModelUpdater
{
    public class QueryModelUpdaterSession:IQueryModelUpdaterSession
    {
        public TModel Get<TModel, TKey>(TKey key)
        {
            using (IRedisClient client = new RedisClient())
            {
                var modelClient = client.As<TModel>();
                return modelClient.GetById(key);
            }
        }

        public void Save<TModel>(TModel model)
        {
            using (IRedisClient client = new RedisClient())
            {
                var modelClient = client.As<TModel>();
                modelClient.Store(model);
            }
        }

        public void Delete<TModel, TKey>(TKey key)
        {
            using (IRedisClient client = new RedisClient())
            {
                var modelClient = client.As<TModel>();
                modelClient.DeleteById(key);
            }
        }

        public void AddToList(string key, string item)
        {
            using (IRedisClient client = new RedisClient())
            {
                client.AddItemToList(key,item);
            }
        }

        public List<string> GetAllItem(string key)
        {
            using (IRedisClient client = new RedisClient())
            {
                return client.GetAllItemsFromList(key);
            }
        }
    }
}