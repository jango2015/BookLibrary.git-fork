using BookLibrary.Core;

namespace BookLibrary.ApplicationService
{
    public interface IApplicationService
    {
        IRepositoryContext Context { get; }
    }
}