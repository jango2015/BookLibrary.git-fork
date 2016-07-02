using System;
using System.Collections.Generic;
using BookLibrary.ApplicationService.Contracts;

namespace BookLibrary.ApplicationService.Implements
{
    public class BookBorrowedProcessService:ApplicationService, IBookBorrowedProcessService
    {
        private readonly DomainService.Contracts.IBookBorrowedProcessService _bookBookBorrowedProcessService;

        public BookBorrowedProcessService(DomainService.Contracts.IBookBorrowedProcessService bookBookBorrowedProcessService)
        {
            _bookBookBorrowedProcessService = bookBookBorrowedProcessService;
        }

        public void BorrowBooks(Guid userId, List<Guid> bookIds, TimeSpan borrowInterval)
        {
            _bookBookBorrowedProcessService.BorrowBooks(userId,bookIds,borrowInterval);
        }

        public void ReturnBook(Guid userId, Guid bookId)
        {
            _bookBookBorrowedProcessService.ReturnBook(userId,bookId);
        }
    }
}