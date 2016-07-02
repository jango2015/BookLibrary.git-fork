using System;
using BookLibrary.DomainModel;

namespace BookLibrary.DomainService.Contracts
{
    public interface IBookService:IDomainService
    {
        Guid AddNewBook(BookModel bookModel);
    }
}