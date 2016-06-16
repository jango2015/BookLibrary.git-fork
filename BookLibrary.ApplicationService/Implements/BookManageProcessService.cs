using System;
using System.Linq;
using BookLibrary.ApplicationService.Contracts;
using BookLibrary.Domain.BookManageProcess;
using BookLibrary.Repository.Contracts;
using BookLibrary.Repository.EntityFramework;

namespace BookLibrary.ApplicationService.Implements
{
    public class BookManageProcessService:EntityFrameworkRepository<BookManageProcess>, IBookManageProcessService
    {
        private readonly IBookManageProcessRepository _bookManageProcessRepository;
        private readonly IBookRepository _bookRepository;

        public BookManageProcessService(IEntityFrameworkContext efContext,
            IBookManageProcessRepository bookManageProcessRepository,
            IBookRepository bookRepository
            ) : base(efContext)
        {
            _bookManageProcessRepository = bookManageProcessRepository;
            _bookRepository = bookRepository;
        }

        public BookManageProcess GetBookManageProcess(Guid userId)
        {
            var bookManageProcess = _bookManageProcessRepository.Find(x => x.UserId == userId).FirstOrDefault();

            return bookManageProcess;
        }

        public void BorrowBook(Guid userId, Guid bookId, TimeSpan borrowInterval)
        {
            var book = _bookRepository.Get(bookId);
            var bookManageProcess = GetBookManageProcess(userId);
            if (bookManageProcess == null)
            {
                bookManageProcess=BookManageProcess.StartNewProcess(userId);
            }

            bookManageProcess.BorrowBook(book,borrowInterval);

            _bookManageProcessRepository.Add(bookManageProcess);
        }

        public void ReturnBook(Guid userId, Guid bookId)
        {
            var bookManageProcess = GetBookManageProcess(userId);
            var book = _bookRepository.Get(bookId);

            bookManageProcess.ReturnBook(book);

            _bookManageProcessRepository.Update(bookManageProcess);
        }
    }
}