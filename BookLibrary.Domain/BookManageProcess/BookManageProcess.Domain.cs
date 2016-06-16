using System;
using System.Diagnostics.Contracts;
using System.Linq;
using BookLibrary.Domain.Exceptions;

namespace BookLibrary.Domain.BookManageProcess
{
    public partial class BookManageProcess
    {
        public static BookManageProcess StartNewProcess(Guid userId)
        {
            return new BookManageProcess(userId);
        }

        public void BorrowBook(Book.Book book,TimeSpan borrowInterval)
        {
            Contract.Requires(book!=null,"book!=null");
            Contract.Requires(borrowInterval>=TimeSpan.FromDays(1),"borrowInterval>TimeSpan.FromDays(1)");

            if (book.Number <= 0)
            {
                throw new BookNotEnoughException($"book:{book.Name} is not enough");
            }

            if(BorrowedBookRecords.Any(x=>x.Book.Name==book.Name))
            {
                throw new BorrowSameBookTwiceException($"already have borrow record for book:{book.Name}");
            }

            book.Borrow();
            var record = new BorrowRecord(UserId, book, borrowInterval);
            BorrowedBookRecords.Add(record);
        }

        public void ReturnBook(Book.Book book)
        {
            Contract.Requires(book != null, "book!=null");

            var borrowRecord = BorrowedBookRecords.Single(x => x.Book.Id == book.Id);

            book.Return();
            var record=new ReturnBookRecord(UserId, book,borrowRecord);
            ReturnedBookRecords.Add(record);
        }
    }
}