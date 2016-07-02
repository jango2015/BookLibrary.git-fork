using System;
using BookLibrary.Core;

namespace BookLibrary.Domain.BookManageProcess
{
    public class ReturnedRecord:Entity
    {
        [Obsolete("for serialization")]
        public ReturnedRecord() { }

        public ReturnedRecord(Guid userId, Book.Book book,BorrowedRecord borrowedRecord)
        {
            Id = Guid.NewGuid();

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

        public Guid UserId { get; private set; }
         public Book.Book Book { get; private set; }
         public DateTime ReturnDate { get; private set; }
         public bool IsPostpone { get; private set; }
         public TimeSpan PostponeDate { get; private set; }

    }
}