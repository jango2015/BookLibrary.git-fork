using System;
using System.Diagnostics.Contracts;
using BookLibrary.Core.Extensions;
using BookLibrary.Model;

namespace BookLibrary.Domain.Book
{
    public partial class Book
    {
        public static Book NewBook(BookModel bookModel)
        {
            Contract.Requires(bookModel!=null,"bookModel!=null");
            Contract.Requires(!bookModel.Name.IsNullOrEmpty());
            Contract.Requires(bookModel.Number>0);

            return new Book()
            {
                Id = Guid.NewGuid(),
                Name = bookModel.Name,
                ISBN = bookModel.ISBN,
                Author = bookModel.Author,
                Number = bookModel.Number,
                Price = bookModel.Price,
                PublishDate = bookModel.PublishDate
            };

        }

        public void Borrow()
        {
            Number--;
        }

        public void Return()
        {
            Number++;
        }
    }
}