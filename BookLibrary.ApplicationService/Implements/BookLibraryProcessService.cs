using System;
using System.Collections.Generic;
using BookLibrary.ApplicationService.Contracts;

namespace BookLibrary.ApplicationService.Implements
{
    public class BookLibraryProcessService:ApplicationService,IBookLibraryProcessService
    {
        private readonly DomainService.Contracts.IBookLibraryProcessDomainService _bookLibraryProcessDomainService;

        public BookLibraryProcessService(DomainService.Contracts.IBookLibraryProcessDomainService bookLibraryProcessDomainService)
        {
            _bookLibraryProcessDomainService = bookLibraryProcessDomainService;
        }

        public void BorrowBooks(Guid userId, List<Guid> bookIds, TimeSpan borrowInterval)
        {
            _bookLibraryProcessDomainService.BorrowBooks(userId,bookIds,borrowInterval);
        }

        public void ReturnBook(Guid userId, Guid bookId)
        {
            _bookLibraryProcessDomainService.ReturnBook(userId,bookId);
        }
    }
}