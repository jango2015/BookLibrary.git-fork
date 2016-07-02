using System;
using System.Collections.Generic;
using System.Linq;
using BookLibrary.Core.Events;

namespace BookLibrary.Domain.Events.BookLibraryProcess
{
    public partial class BookLibraryProcessEvent
    {
        public class BookLibraryProcessUpdatedEvent : IEntityCreatedEvent, IBookLibraryEvent
        {
            [Obsolete("for serilization")]
            public BookLibraryProcessUpdatedEvent()
            {
                BookBorrowedRecords = new List<BorrowedRecord>();
                BookReturnedRecords = new List<ReturnedRecord>();
            }

            public BookLibraryProcessUpdatedEvent(BorrowedProcess.BookLibraryProcess bookLibraryProcess)
            {
                BookBorrowedProcessId = bookLibraryProcess.Id;
                UserId = bookLibraryProcess.UserId;
                BookBorrowedRecords = bookLibraryProcess.BookBorrowedRecords.Select(x => new BorrowedRecord(x)).ToList();
                BookReturnedRecords = bookLibraryProcess.BookReturnedRecords.Select(x => new ReturnedRecord(x)).ToList();
            }

            public Guid BookBorrowedProcessId { get; private set; }
            public Guid UserId { get; private set; }
            public DateTime BorrowDate { get; private set; }
            public List<BorrowedRecord> BookBorrowedRecords { get; private set; }
            public List<ReturnedRecord> BookReturnedRecords { get; private set; }
           
        }

    }
}