using BookLibrary.Core;

namespace BookLibrary.Repository.Exceptions
{
    public class NoSuchAggregateRootException: BookLibraryException
    {
        public NoSuchAggregateRootException(string message) : base(message)
        {
        }
    }
}