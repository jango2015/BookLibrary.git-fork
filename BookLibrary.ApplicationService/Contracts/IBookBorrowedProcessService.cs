using System;
using BookLibrary.Domain.BookManageProcess;

namespace BookLibrary.ApplicationService.Contracts
{
    public interface IBookBorrowedProcessService:IApplicationService
    {
        BookBorrowedProcess GetBookBorrowedProcess(Guid userId);

        void BorrowBook(Guid userId, Guid bookId, TimeSpan borrowInterval);

        void ReturnBook(Guid userId, Guid bookId);
    }
}