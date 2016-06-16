namespace BookLibrary.Core.Uow
{
    public interface ICurrentUnitOfWorkProvider
    {
         IUnitOfWork Current { get; set; }
    }
}