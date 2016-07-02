using System;

namespace BookLibrary.Domain.Events.BookLibraryProcess
{
    public partial class BookLibraryProcessEvent
    {
        public class BorrowedRecord
        {
            [Obsolete("for serilization")]
            public BorrowedRecord()
            {
            }

            public BorrowedRecord(BorrowedProcess.BorrowedRecord borrowedRecord)
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
            public ReturnedRecord()
            {
            }

            public ReturnedRecord(BorrowedProcess.ReturnedRecord returnedRecord)
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