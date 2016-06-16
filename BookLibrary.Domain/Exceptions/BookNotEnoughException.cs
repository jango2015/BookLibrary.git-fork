namespace BookLibrary.Domain.Exceptions
{
    public class BookNotEnoughException:DomainException
    {
        public BookNotEnoughException(string message) : base(message)
        {
        }
    }
}