using System;
using BookLibrary.Model;

namespace BookLibrary.ApplicationService.Contracts
{
    public interface IBookService:IApplicationService
    {
        Guid AddNewBook(BookModel bookModel);
    }
}