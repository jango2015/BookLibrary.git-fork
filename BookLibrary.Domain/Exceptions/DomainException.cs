using BookLibrary.Core;

namespace BookLibrary.Domain.Exceptions
{
    public class DomainException : BookLibraryException
    {
        public DomainException(string message):base(message)
        {
            
        }
    }
}