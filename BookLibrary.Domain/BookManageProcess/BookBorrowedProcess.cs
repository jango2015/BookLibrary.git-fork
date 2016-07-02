using System;
using System.Collections.Generic;
using BookLibrary.Core;

namespace BookLibrary.Domain.BookManageProcess
{
    public partial class BookBorrowedProcess:AggregateRoot<BookBorrowedProcess>
    {
        [Obsolete("for serialization")]
        public BookBorrowedProcess()
        {
            BookBorrowedRecords = new List<BorrowedRecord>();
            BookReturnedRecords = new List<ReturnedRecord>();
        }

        public BookBorrowedProcess(Guid userId) : this()
        {
            UserId = userId;
            Id = Guid.NewGuid();
            BorrowDate=DateTime.Now;
        }

        public Guid UserId { get; private set; }
        public DateTime BorrowDate { get; private set; }
        public virtual List<BorrowedRecord> BookBorrowedRecords { get; private set; }
        public virtual List<ReturnedRecord> BookReturnedRecords { get; private set; }


    }
}