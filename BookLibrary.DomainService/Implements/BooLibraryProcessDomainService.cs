using System;
using System.Collections.Generic;
using System.Linq;
using BookLibrary.Core;
using BookLibrary.Domain.Book;
using BookLibrary.Domain.BorrowedProcess;
using BookLibrary.DomainService.Contracts;
using BookLibrary.Repository.Contracts;

namespace BookLibrary.DomainService.Implements
{
    public class BooLibraryProcessDomainService:DomainService,IBookLibraryProcessDomainService
    {
        private readonly IBookLibraryProcessRepository _bookLibraryProcessRepository;
        private readonly IBookRepository _bookRepository;

        public BooLibraryProcessDomainService(IBookLibraryProcessRepository bookLibraryProcessRepository,
            IBookRepository bookRepository,IRepositoryContext context) : base(context)
        {
            _bookLibraryProcessRepository = bookLibraryProcessRepository;
            _bookRepository = bookRepository;
        }

        public BookLibraryProcess GetBookLibraryProcess(Guid bookBorrowedProcessId)
        {
            var borrowedProcess = _bookLibraryProcessRepository.Find(x => x.Id == bookBorrowedProcessId).FirstOrDefault();

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

            var borrowedProcess = BookLibraryProcess.StartNewProcess(userId);
            borrowedProcess.BorrowBooks(books, borrowInterval);
            _bookLibraryProcessRepository.Add(borrowedProcess);
        }

        public void ReturnBook(Guid bookBorrowedProcessId, Guid bookId)
        {
            var bookBorrowedProcess = GetBookLibraryProcess(bookBorrowedProcessId);
            var book = _bookRepository.Get(bookId);

            bookBorrowedProcess.ReturnBook(book);

            _bookLibraryProcessRepository.Update(bookBorrowedProcess);
        }
    }
}