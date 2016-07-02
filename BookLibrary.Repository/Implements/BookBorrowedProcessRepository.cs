using BookLibrary.Domain.BookManageProcess;
using BookLibrary.Repository.Contracts;
using BookLibrary.Repository.EntityFramework;

namespace BookLibrary.Repository.Implements
{
    public class BookBorrowedProcessRepository : EntityFrameworkRepository<BookBorrowedProcess>, IBookBorrowedProcessRepository
    {
        public BookBorrowedProcessRepository(IEntityFrameworkContext efContext)
          : base(efContext)
        {
        }
    }
}