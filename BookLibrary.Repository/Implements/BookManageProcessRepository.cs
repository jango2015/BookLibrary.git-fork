using BookLibrary.Domain.BookManageProcess;
using BookLibrary.Repository.Contracts;
using BookLibrary.Repository.EntityFramework;

namespace BookLibrary.Repository.Implements
{
    public class BookManageProcessRepository : EntityFrameworkRepository<BookManageProcess>, IBookManageProcessRepository
    {
        public BookManageProcessRepository(IEntityFrameworkContext efContext)
          : base(efContext)
        {
        }
    }
}