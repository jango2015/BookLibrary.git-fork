using System;
using BookLibrary.Core;

namespace BookLibrary.Domain.BookManageProcess
{
    public class BorrowedRecord:Entity
    {
        [Obsolete("for serialization")]
        public BorrowedRecord() { }

        public BorrowedRecord(Guid userId, Book.Book book, TimeSpan borrowInterval)
        {
            Id = Guid.NewGuid();

            UserId = userId;
            Book = book;
            BorrowInterval = borrowInterval;
            BorrowDate=DateTime.Now;
        }

         public Guid UserId { get; private set; }
         public Book.Book Book { get; private set; }
         public DateTime BorrowDate { get; private set; }
         public TimeSpan BorrowInterval { get; private set; }
    }
}