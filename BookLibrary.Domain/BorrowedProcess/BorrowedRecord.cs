using System;
using BookLibrary.Core;

namespace BookLibrary.Domain.BorrowedProcess
{
    public class BorrowedRecord:Entity
    {
        [Obsolete("for serialization")]
        public BorrowedRecord() { }

        public BorrowedRecord(BookBorrowedProcess bookBorrowedProcess, Guid userId, Book.Book book, TimeSpan borrowInterval)
        {
            Id = Guid.NewGuid();

            BookBorrowedProcess = bookBorrowedProcess;
            UserId = userId;
            Book = book;
            BorrowInterval = borrowInterval;
            BorrowDate=DateTime.Now;
        }
        public BookBorrowedProcess BookBorrowedProcess { get; set; }
         public Guid UserId { get; private set; }
         public Book.Book Book { get; private set; }
         public DateTime BorrowDate { get; private set; }
         public TimeSpan BorrowInterval { get; private set; }
    }
}