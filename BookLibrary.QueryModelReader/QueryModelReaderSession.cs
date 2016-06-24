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
      
    }
}