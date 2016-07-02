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
            BorrowedBookRecords = new List<BorrowedRecord>();
            ReturnedBookRecords = new List<ReturnedRecord>();
        }

        public BookBorrowedProcess(Guid userId) : this()
        {
            UserId = userId;
            Id = Guid.NewGuid();
        }

        public Guid UserId { get; private set; }
        public List<BorrowedRecord> BorrowedBookRecords { get; private set; }
        public List<ReturnedRecord> ReturnedBookRecords { get; private set; }


    }
}