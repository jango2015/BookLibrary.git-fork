using System;
using System.Collections.Generic;
using System.Linq;
using BookLibrary.Core.Events;

namespace BookLibrary.Domain.Events.BookBorrowedProcess
{
    public partial class BookBorrowedProcessEvent
    {
        public class BookBorrowedProcessUpdatedEvent : IEntityCreatedEvent, IBookLibraryEvent
        {
            [Obsolete("for serilization")]
            public BookBorrowedProcessUpdatedEvent()
            {
                BookBorrowedRecords = new List<BorrowedRecord>();
                BookReturnedRecords = new List<ReturnedRecord>();
            }

            public BookBorrowedProcessUpdatedEvent(BorrowedProcess.BookBorrowedProcess bookBorrowedProcess)
            {
                BookBorrowedProcessId = bookBorrowedProcess.Id;
                UserId = bookBorrowedProcess.UserId;
                BookBorrowedRecords = bookBorrowedProcess.BookBorrowedRecords.Select(x => new BorrowedRecord(x)).ToList();
                BookReturnedRecords = bookBorrowedProcess.BookReturnedRecords.Select(x => new ReturnedRecord(x)).ToList();
            }

            public Guid BookBorrowedProcessId { get; private set; }
            public Guid UserId { get; private set; }
            public DateTime BorrowDate { get; private set; }
            public List<BorrowedRecord> BookBorrowedRecords { get; private set; }
            public List<ReturnedRecord> BookReturnedRecords { get; private set; }
           
        }

    }
}