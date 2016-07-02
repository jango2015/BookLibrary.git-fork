using System;
using BookLibrary.DomainModel;

namespace BookLibrary.DomainService.Contracts
{
    public interface IBookDomainService:IDomainService
    {
        Guid AddNewBook(BookModel bookModel);
    }
}