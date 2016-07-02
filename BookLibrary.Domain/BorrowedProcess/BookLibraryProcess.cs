using System;
using System.Collections.Generic;
using BookLibrary.Core;

namespace BookLibrary.Domain.BorrowedProcess
{
    public partial class BookLibraryProcess:AggregateRoot<BookLibraryProcess>
    {
        [Obsolete("for serialization")]
        public BookLibraryProcess()
        {
            BookBorrowedRecords = new List<BorrowedRecord>();
            BookReturnedRecords = new List<ReturnedRecord>();
        }

        public BookLibraryProcess(Guid userId) : this()
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