using System.Collections.Generic;
using ServiceStack;
using ServiceStack.Redis;

namespace BookLibrary.QueryModelUpdater
{
    public class QueryModelUpdaterSession:IQueryModelUpdaterSession
    {
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

        public void AddItemToSet(string key, string item)
        {
            using (IRedisClient client = new RedisClient())
            {
                client.AddItemToSet(key, item);
            }
        }
        
       
    }
}