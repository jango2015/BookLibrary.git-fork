using System;
using BookLibrary.Core;

namespace BookLibrary.Domain.BookManageProcess
{
    public class ReturnBookRecord:Entity
    {
        [Obsolete("for serialization")]
        public ReturnBookRecord() { }

        public ReturnBookRecord(Guid userId, Book.Book book,BorrowRecord borrowRecord)
        {
            Id = Guid.NewGuid();

            UserId = userId;
            Book = book;
            ReturnDate=DateTime.Now;

            var interval = DateTime.Now.Subtract(borrowRecord.BorrowDate);
            if (interval > borrowRecord.BorrowInterval)
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