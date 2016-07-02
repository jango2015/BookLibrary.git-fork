using System;
using System.Collections.Generic;
using System.Linq;
using BookLibrary.Core.Event;

namespace BookLibrary.Domain.Events.BookBorrowedProcess
{
    public class BookBorrowedProcessUpdatedEvent:IEntityCreatedEvent,IBookLibraryEvent
    {
        [Obsolete("for serilization")]
        public BookBorrowedProcessUpdatedEvent()
        {
            BookBorrowedRecords=new List<BorrowedRecord>();
            BookReturnedRecords=new List<ReturnedRecord>();
        }

        public BookBorrowedProcessUpdatedEvent(BookManageProcess.BookBorrowedProcess bookBorrowedProcess)
        {
            BookBorrowedProcessId = bookBorrowedProcess.Id;
            UserId = bookBorrowedProcess.UserId;
            BookBorrowedRecords = bookBorrowedProcess.BookBorrowedRecords.Select(x => new BorrowedRecord(x)).ToList();
            BookReturnedRecords = bookBorrowedProcess.BookReturnedRecords.Select(x => new ReturnedRecord(x)).ToList();
        }

        public Guid BookBorrowedProcessId { get; private set; }
        public Guid UserId { get; private set; }
        public  List<BorrowedRecord> BookBorrowedRecords { get; private set; }
        public  List<ReturnedRecord> BookReturnedRecords { get; private set; }

        public class BorrowedRecord
        {
            [Obsolete("for serilization")]
            public BorrowedRecord() { }
            public BorrowedRecord(BookManageProcess.BorrowedRecord borrowedRecord)
            {
                UserId = borrowedRecord.UserId;
                BookId = borrowedRecord.Book.Id;
                BorrowDate = borrowedRecord.BorrowDate;
                BorrowInterval = borrowedRecord.BorrowInterval;

            }
            public Guid UserId { get; private set; }
            public Guid BookId { get; private set; }
            public DateTime BorrowDate { get; private set; }
            public TimeSpan BorrowInterval { get; private set; }
        }

        public class ReturnedRecord
        {
            [Obsolete("for serilization")]
            public ReturnedRecord() { }

            public ReturnedRecord(BookManageProcess.ReturnedRecord returnedRecord)
            {
                UserId = returnedRecord.UserId;
                BookId = returnedRecord.Book.Id;
                ReturnDate = returnedRecord.ReturnDate;
                IsPostpone = returnedRecord.IsPostpone;
                PostponeDate = returnedRecord.PostponeDate;
            }

            public Guid UserId { get; private set; }
            public Guid BookId { get; private set; }
            public DateTime ReturnDate { get; private set; }
            public bool IsPostpone { get; private set; }
            public TimeSpan PostponeDate { get; private set; }
        }
    }
}