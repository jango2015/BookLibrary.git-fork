using System;
using BookLibrary.DomainModel;

namespace BookLibrary.ApplicationService.Contracts
{
    public interface IBookService:IApplicationService
    {
        Guid AddNewBook(BookModel bookModel);
    }
}