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

        public BookBorrowedProcess GetBookBorrowedProcess(Guid userId)
        {
            var borrowedProcess = _bookBorrowedProcessRepository.Find(x => x.UserId == userId).FirstOrDefault();

            return borrowedProcess;
        }

        public void BorrowBook(Guid userId, Guid bookId, TimeSpan borrowInterval)
        {
            var book = _bookRepository.Get(bookId);
            var borrowedProcess = GetBookBorrowedProcess(userId);
            if (borrowedProcess == null)
            {
                borrowedProcess=BookBorrowedProcess.StartNewProcess(userId);
            }

            borrowedProcess.BorrowBook(book,borrowInterval);

            _bookBorrowedProcessRepository.Add(borrowedProcess);
        }

        public void ReturnBook(Guid userId, Guid bookId)
        {
            var bookBorrowedProcess = GetBookBorrowedProcess(userId);
            var book = _bookRepository.Get(bookId);

            bookBorrowedProcess.ReturnBook(book);

            _bookBorrowedProcessRepository.Update(bookBorrowedProcess);
        }
    }
}