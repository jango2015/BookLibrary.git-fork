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
    }
}