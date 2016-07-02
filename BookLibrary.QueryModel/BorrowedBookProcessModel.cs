using System;
using System.Collections.Generic;
using System.Linq;
using BookLibrary.Domain.Events.BookBorrowedProcess;

namespace BookLibrary.QueryModel
{
    public class BorrowedBookProcessModel
    {
        public BorrowedBookProcessModel(BookBorrowedProcessEvent.BookBorrowedProcessCreatedEvent evt)
        {
            BookBorrowedProcessId = evt.BookBorrowedProcessId;
            UserId = evt.UserId;
            BorrowDate = evt.BorrowDate;
            BookBorrowedRecords = evt.BookBorrowedRecords.Select(x => new BorrowedRecord(x)).ToList();
            BookReturnedRecords = evt.BookReturnedRecords.Select(x => new ReturnedRecord(x)).ToList();
        }

        public BorrowedBookProcessModel(BookBorrowedProcessEvent.BookBorrowedProcessUpdatedEvent evt)
        {
            BookBorrowedProcessId = evt.BookBorrowedProcessId;
            UserId = evt.UserId;
            BorrowDate = evt.BorrowDate;
            BookBorrowedRecords = evt.BookBorrowedRecords.Select(x => new BorrowedRecord(x)).ToList();
            BookReturnedRecords = evt.BookReturnedRecords.Select(x => new ReturnedRecord(x)).ToList();
        }

        public Guid BookBorrowedProcessId { get; set; }
        public Guid UserId { get; set; }
        public DateTime BorrowDate { get; set; }
        public  List<BorrowedRecord> BookBorrowedRecords { get; set; }
        public  List<ReturnedRecord> BookReturnedRecords { get; set; }

        public class BorrowedRecord
        {
            [Obsolete("for serilization")]
            public BorrowedRecord() { }
            public BorrowedRecord(BookBorrowedProcessEvent.BorrowedRecord borrowedRecord)
            {
                UserId = borrowedRecord.UserId;
                BookId = borrowedRecord.BookId;
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

            public ReturnedRecord(BookBorrowedProcessEvent.ReturnedRecord returnedRecord)
            {
                UserId = returnedRecord.UserId;
                BookId = returnedRecord.BookId;
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