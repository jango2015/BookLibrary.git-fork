using System;
using BookLibrary.ApplicationService.Contracts;
using BookLibrary.Core;
using BookLibrary.Domain.Book;
using BookLibrary.DomainModel;

namespace BookLibrary.ApplicationService.Implements
{
    public class BookService:ApplicationService,IBookService
    {
        private readonly DomainService.Contracts.IBookService _bookService;

        public BookService(DomainService.Contracts.IBookService bookService)
        {
            _bookService = bookService;
        }

        public Guid AddNewBook(BookModel bookModel)
        {
           return _bookService.AddNewBook(bookModel);
        }
    }
}