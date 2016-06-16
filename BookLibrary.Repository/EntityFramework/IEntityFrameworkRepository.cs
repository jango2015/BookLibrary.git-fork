using BookLibrary.Core;

namespace BookLibrary.Repository.EntityFramework
{
    public interface IEntityFrameworkRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        IEntityFrameworkContext EfContext { get; }
    }
}