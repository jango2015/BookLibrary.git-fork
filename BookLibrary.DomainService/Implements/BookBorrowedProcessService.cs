using System;
using System.Collections.Generic;
using System.Linq;
using BookLibrary.Core;
using BookLibrary.Domain.Book;
using BookLibrary.Domain.BookManageProcess;
using BookLibrary.DomainService.Contracts;
using BookLibrary.Repository.Contracts;

namespace BookLibrary.DomainService.Implements
{
    public class BookBorrowedProcessService:DomainService,IBookBorrowedProcessService
    {
        private readonly IBookBorrowedProcessRepository _bookBorrowedProcessRepository;
        private readonly IBookRepository _bookRepository;

        public BookBorrowedProcessService(IBookBorrowedProcessRepository bookBorrowedProcessRepository,
            IBookRepository bookRepository,IRepositoryContext context) : base(context)
        {
            _bookBorrowedProcessRepository = bookBorrowedProcessRepository;
            _bookRepository = bookRepository;
        }

        public BookBorrowedProcess GetBookBorrowedProcess(Guid bookBorrowedProcessId)
        {
            var borrowedProcess = _bookBorrowedProcessRepository.Find(x => x.Id == bookBorrowedProcessId).FirstOrDefault();

            return borrowedProcess;
        }

        public void BorrowBooks(Guid userId, List<Guid> bookIds, TimeSpan borrowInterval)
        {
            var books = new List<Book>();
            bookIds.ForEach(id =>
            {
                var book = _bookRepository.Get(id);
                books.Add(book);
            });

            var borrowedProcess = BookBorrowedProcess.StartNewProcess(userId);
            borrowedProcess.BorrowBooks(books, borrowInterval);
            _bookBorrowedProcessRepository.Add(borrowedProcess);
        }

        public void ReturnBook(Guid bookBorrowedProcessId, Guid bookId)
        {
            var bookBorrowedProcess = GetBookBorrowedProcess(bookBorrowedProcessId);
            var book = _bookRepository.Get(bookId);

            bookBorrowedProcess.ReturnBook(book);

            _bookBorrowedProcessRepository.Update(bookBorrowedProcess);
        }
    }
}