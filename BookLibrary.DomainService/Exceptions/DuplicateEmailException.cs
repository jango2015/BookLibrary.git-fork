using BookLibrary.Domain.Exceptions;

namespace BookLibrary.DomainService.Exceptions
{
    public class DuplicateEmailException:DomainServiceException
    {
        public DuplicateEmailException(string message) : base(message)
        {
        }
    }
}