using System;
using BookLibrary.ApplicationService.Contracts;
using BookLibrary.Core;
using BookLibrary.Domain.Book;
using BookLibrary.DomainModel;

namespace BookLibrary.ApplicationService.Implements
{
    public class BookService:IBookService
    {
        private readonly DomainService.Contracts.IBookDomainService _bookDomainService;

        public BookService(DomainService.Contracts.IBookDomainService bookDomainService)
        {
            _bookDomainService = bookDomainService;
        }

        public Guid AddNewBook(BookModel bookModel)
        {
           return _bookDomainService.AddNewBook(bookModel);
        }
    }
}