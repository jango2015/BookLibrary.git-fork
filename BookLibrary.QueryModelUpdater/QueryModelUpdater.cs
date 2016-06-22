//using System.Linq;
//using BookLibrary.Core.Event;

//namespace BookLibrary.QueryModelUpdater
//{
//    public class QueryModelUpdater<TUpdater, TQueryModel, TEntityChangedEvent>
//        where TUpdater : QueryModelUpdater<TUpdater, TQueryModel, TEntityChangedEvent>
//    {
//        private readonly IQueryModelUpdaterSession _session;

//        public QueryModelUpdater(IQueryModelUpdaterSession session)
//        {
//            _session = session;
//        }

//        //public virtual void Handle(TEntityChangedEvent evt)
//        //{
//        //    if (evt is IEntityCreatedEvent || evt is IEntityUpdatedEvent)
//        //    {
                
//        //    }
//        //}
//    }
//}