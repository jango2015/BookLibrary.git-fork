using System;
using BookLibrary.Core;
using BookLibrary.Domain.Book;
using BookLibrary.DomainModel;
using BookLibrary.DomainService.Contracts;
using BookLibrary.Repository.Contracts;

namespace BookLibrary.DomainService.Implements
{
    public class BookDomainService:DomainService,IBookDomainService
    {
        private readonly IBookRepository _bookRepository;

        public BookDomainService(IRepositoryContext context, IBookRepository bookRepository) : base(context)
        {
            _bookRepository = bookRepository;
        }

        public Guid AddNewBook(BookModel bookModel)
        {
            var book = Book.NewBook(bookModel);

            _bookRepository.Add(book);

            return book.Id;
        }
    }
}