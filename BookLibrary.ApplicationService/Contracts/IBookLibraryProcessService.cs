using System;
using System.Collections.Generic;

namespace BookLibrary.ApplicationService.Contracts
{
    public interface IBookLibraryProcessService:IApplicationService
    {
        void BorrowBooks(Guid userId, List<Guid> bookIds, TimeSpan borrowInterval);

        void ReturnBook(Guid userId, Guid bookId);
    }
}