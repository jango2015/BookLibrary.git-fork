namespace BookLibrary.Domain.User
{
    public interface IEmailUniqueChecker
    {
        bool IsExist(string email);
    }
}