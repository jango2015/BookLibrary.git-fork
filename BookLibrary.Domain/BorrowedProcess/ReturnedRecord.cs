using System;
using BookLibrary.Core;

namespace BookLibrary.Domain.BorrowedProcess
{
    public class ReturnedRecord:Entity
    {
        [Obsolete("for serialization")]
        public ReturnedRecord() { }

        public ReturnedRecord(BookLibraryProcess bookLibraryProcess, Guid userId, Book.Book book,BorrowedRecord borrowedRecord)
        {
            Id = Guid.NewGuid();

            BookLibraryProcess = bookLibraryProcess;
            UserId = userId;
            Book = book;
            ReturnDate=DateTime.Now;

            var interval = DateTime.Now.Subtract(borrowedRecord.BorrowDate);
            if (interval > borrowedRecord.BorrowInterval)
            {
                IsPostpone = true;
                PostponeDate = interval;
            }
            else
            {
                IsPostpone = false;
                PostponeDate=TimeSpan.Zero;
            }
        }

        public BookLibraryProcess BookLibraryProcess { get; private set; }
        public Guid UserId { get; private set; }
         public Book.Book Book { get; private set; }
         public DateTime ReturnDate { get; private set; }
         public bool IsPostpone { get; private set; }
         public TimeSpan PostponeDate { get; private set; }

    }
}