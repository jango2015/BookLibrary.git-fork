using BookLibrary.Domain.BorrowedProcess;
using BookLibrary.Repository.Contracts;
using BookLibrary.Repository.EntityFramework;

namespace BookLibrary.Repository.Implements
{
    public class BookLibraryProcessRepository : EntityFrameworkRepository<BookLibraryProcess>, IBookLibraryProcessRepository
    {
        public BookLibraryProcessRepository(IEntityFrameworkContext efContext)
          : base(efContext)
        {
        }
    }
}