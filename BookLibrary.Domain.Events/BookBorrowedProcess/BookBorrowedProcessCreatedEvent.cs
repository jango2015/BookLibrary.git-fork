using System;
using System.Collections.Generic;
using BookLibrary.Core.Event;

namespace BookLibrary.Domain.Events.BookBorrowedProcess
{
    public class BookBorrowedProcessCreatedEvent:IEntityCreatedEvent,IBookLibraryEvent
    {
        [Obsolete("for serilization")]
        public BookBorrowedProcessCreatedEvent() { }

        public BookBorrowedProcessCreatedEvent()
        {
            
        }

        public Guid BookBorrowedProcessId { get; private set; }
        public Guid UserId { get; private set; }
        public  List<BorrowedRecord> BookBorrowedRecords { get; private set; }
        public  List<ReturnedRecord> BookReturnedRecords { get; private set; }

        public class BorrowedRecord
        {
             
        }

        public class ReturnedRecord
        {
             
        }
    }
}