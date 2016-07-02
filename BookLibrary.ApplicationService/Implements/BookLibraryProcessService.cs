using System;
using System.Collections.Generic;
using BookLibrary.ApplicationService.Contracts;

namespace BookLibrary.ApplicationService.Implements
{
    public class BookLibraryProcessService:ApplicationService,IBookLibraryProcessService
    {
        private readonly DomainService.Contracts.IBookLibraryProcessService _bookLibraryProcessService;

        public BookLibraryProcessService(DomainService.Contracts.IBookLibraryProcessService bookLibraryProcessService)
        {
            _bookLibraryProcessService = bookLibraryProcessService;
        }

        public void BorrowBooks(Guid userId, List<Guid> bookIds, TimeSpan borrowInterval)
        {
            _bookLibraryProcessService.BorrowBooks(userId,bookIds,borrowInterval);
        }

        public void ReturnBook(Guid userId, Guid bookId)
        {
            _bookLibraryProcessService.ReturnBook(userId,bookId);
        }
    }
}