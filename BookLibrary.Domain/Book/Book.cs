using System;
using BookLibrary.Core;

namespace BookLibrary.Domain.Book
{
    public partial class Book : AggregateRoot<Book>
    {
        public string Name { get; private set; }

        public string ISBN { get; private set; }

        public string Author { get; private set; }

        public decimal Price { get; private set; }

        public int Number { get; private set; }

        public DateTime PublishDate { get; private set; }

    }
}