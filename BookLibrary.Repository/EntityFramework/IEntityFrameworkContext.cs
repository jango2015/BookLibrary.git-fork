using System.Data.Entity;
using BookLibrary.Core;

namespace BookLibrary.Repository.EntityFramework
{
    public interface IEntityFrameworkContext : IRepositoryContext
    {
        DbContext DbContext { get; }
    }
}