using System;
using System.Collections.Generic;
using BookLibrary.Domain.BorrowedProcess;

namespace BookLibrary.DomainService.Contracts
{
    public interface IBookLibraryProcessDomainService:IDomainService
    {
        BookLibraryProcess GetBookLibraryProcess(Guid bookBorrowedProcessId);

        void BorrowBooks(Guid userId, List<Guid> bookIds, TimeSpan borrowInterval);

        void ReturnBook(Guid userId, Guid bookId);
    }
}