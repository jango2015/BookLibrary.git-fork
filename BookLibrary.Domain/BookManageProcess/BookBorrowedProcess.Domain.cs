using System;
using System.Diagnostics.Contracts;
using System.Linq;
using BookLibrary.Domain.Exceptions;

namespace BookLibrary.Domain.BookManageProcess
{
    public partial class BookBorrowedProcess
    {
        public static BookBorrowedProcess StartNewProcess(Guid userId)
        {
            return new BookBorrowedProcess(userId);
        }

        public void BorrowBook(Book.Book book,TimeSpan borrowInterval)
        {
            Contract.Requires(book!=null,"book!=null");
            Contract.Requires(borrowInterval>=TimeSpan.FromDays(1),"borrowInterval>TimeSpan.FromDays(1)");

            if (book.Number <= 0)
            {
                throw new BookNotEnoughException($"book:{book.Name} is not enough");
            }

            if(BookBorrowedRecords.Any(x=>x.Book.ISBN==book.ISBN))
            {
                throw new BorrowSameBookTwiceException($"already have borrowed record for book:{book.Name}");
            }

            book.Borrow();
            var record = new BorrowedRecord(UserId, book, borrowInterval);
            BookBorrowedRecords.Add(record);
        }

        public void ReturnBook(Book.Book book)
        {
            Contract.Requires(book != null, "book!=null");

            var borrowRecord = BookBorrowedRecords.Single(x => x.Book.Id == book.Id);

            book.Return();
            var record=new ReturnedRecord(UserId, book,borrowRecord);
            BookReturnedRecords.Add(record);
        }
    }
}