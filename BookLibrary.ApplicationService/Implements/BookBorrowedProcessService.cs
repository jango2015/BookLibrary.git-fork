using System;
using System.Linq;
using BookLibrary.ApplicationService.Contracts;
using BookLibrary.Domain.BookManageProcess;
using BookLibrary.Repository.Contracts;
using BookLibrary.Repository.EntityFramework;

namespace BookLibrary.ApplicationService.Implements
{
    public class BookBorrowedProcessService:EntityFrameworkRepository<BookBorrowedProcess>, IBookBorrowedProcessService
    {
        private readonly IBookBorrowedProcessRepository _bookBorrowedProcessRepository;
        private readonly IBookRepository _bookRepository;

        public BookBorrowedProcessService(IEntityFrameworkContext efContext,
            IBookBorrowedProcessRepository bookBorrowedProcessRepository,
            IBookRepository bookRepository
            ) : base(efContext)
        {
            _bookBorrowedProcessRepository = bookBorrowedProcessRepository;
            _bookRepository = bookRepository;
        }

        public BookBorrowedProcess GetBookBorrowProcess(Guid userId)
        {
            var bookManageProcess = _bookBorrowedProcessRepository.Find(x => x.UserId == userId).FirstOrDefault();

            return bookManageProcess;
        }

        public void BorrowBook(Guid userId, Guid bookId, TimeSpan borrowInterval)
        {
            var book = _bookRepository.Get(bookId);
            var bookManageProcess = GetBookBorrowProcess(userId);
            if (bookManageProcess == null)
            {
                bookManageProcess=BookBorrowedProcess.StartNewProcess(userId);
            }

            bookManageProcess.BorrowBook(book,borrowInterval);

            _bookBorrowedProcessRepository.Add(bookManageProcess);
        }

        public void ReturnBook(Guid userId, Guid bookId)
        {
            var bookManageProcess = GetBookBorrowProcess(userId);
            var book = _bookRepository.Get(bookId);

            bookManageProcess.ReturnBook(book);

            _bookBorrowedProcessRepository.Update(bookManageProcess);
        }
    }
}