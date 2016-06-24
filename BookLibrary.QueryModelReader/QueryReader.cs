namespace BookLibrary.QueryModelReader
{
    public class QueryReader
    {
        protected readonly IQueryModelReaderSession Session;

        public QueryReader(IQueryModelReaderSession session)
        {
            Session = session;
        }
    }
}