using BookLibrary.Core;
using BookLibrary.Domain.BorrowedProcess;

namespace BookLibrary.Repository.Contracts
{
    public interface IBookBorrowedProcessRepository : IRepository<BookBorrowedProcess>
    {
    }
}