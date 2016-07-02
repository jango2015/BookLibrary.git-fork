using System;
using BookLibrary.Core;

namespace BookLibrary.Domain.BorrowedProcess
{
    public class BorrowedRecord:Entity
    {
        [Obsolete("for serialization")]
        public BorrowedRecord() { }

        public BorrowedRecord(BookLibraryProcess bookLibraryProcess, Guid userId, Book.Book book, TimeSpan borrowInterval)
        {
            Id = Guid.NewGuid();

            BookLibraryProcess = bookLibraryProcess;
            UserId = userId;
            Book = book;
            BorrowInterval = borrowInterval;
            BorrowDate=DateTime.Now;
        }
        public BookLibraryProcess BookLibraryProcess { get; set; }
         public Guid UserId { get; private set; }
         public Book.Book Book { get; private set; }
         public DateTime BorrowDate { get; private set; }
         public TimeSpan BorrowInterval { get; private set; }
    }
}