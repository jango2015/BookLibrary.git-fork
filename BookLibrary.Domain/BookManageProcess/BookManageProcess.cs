using System;
using System.Collections.Generic;
using BookLibrary.Core;

namespace BookLibrary.Domain.BookManageProcess
{
    public partial class BookManageProcess:AggregateRoot<BookManageProcess>
    {
        [Obsolete("for serialization")]
        public BookManageProcess()
        {
            BorrowedBookRecords = new List<BorrowRecord>();
            ReturnedBookRecords = new List<ReturnBookRecord>();
        }

        public BookManageProcess(Guid userId) : this()
        {
            UserId = userId;
            Id = Guid.NewGuid();
        }

        public Guid UserId { get; private set; }
        public List<BorrowRecord> BorrowedBookRecords { get; private set; }
        public List<ReturnBookRecord> ReturnedBookRecords { get; private set; }


    }
}