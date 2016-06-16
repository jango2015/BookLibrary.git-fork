namespace BookLibrary.Domain.Exceptions
{
    public class BorrowSameBookTwiceException:DomainException
    {
        public BorrowSameBookTwiceException(string message) : base(message)
        {
        }
    }
}