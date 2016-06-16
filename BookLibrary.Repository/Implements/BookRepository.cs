using BookLibrary.Domain.Book;
using BookLibrary.Repository.Contracts;
using BookLibrary.Repository.EntityFramework;

namespace BookLibrary.Repository.Implements
{
    public class BookRepository: EntityFrameworkRepository<Book>,IBookRepository
    {
        public BookRepository(IEntityFrameworkContext efContext) : base(efContext)
        {
        }
    }
}