using BookLibrary.Core;

namespace BookLibrary.DomainService.Exceptions
{
    public class DomainServiceException: BookLibraryException
    {
        public DomainServiceException(string message) : base(message)
        {
        }
    }
}