namespace BookLibrary.Domain.Exceptions
{
    public class DuplicateEmailException:DomainException
    {
        public DuplicateEmailException(string message) : base(message)
        {
        }
    }
}