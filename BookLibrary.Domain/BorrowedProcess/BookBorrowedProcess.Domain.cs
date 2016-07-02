using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using BookLibrary.Core.Extensions;
using BookLibrary.Core.ServiceBus;
using BookLibrary.Domain.Events.BookBorrowedProcess;
using BookLibrary.Domain.Exceptions;

namespace BookLibrary.Domain.BorrowedProcess
{
    public partial class BookBorrowedProcess
    {
        public static BookBorrowedProcess StartNewProcess(Guid userId)
        {
            return new BookBorrowedProcess(userId);
        }

        public void BorrowBooks(List<Book.Book> books, TimeSpan borrowInterval)
        {
            Contract.Requires(books!=null);
            Contract.Requires(books.Count>0);
            Contract.Requires(borrowInterval >= TimeSpan.FromDays(1), "borrowInterval>TimeSpan.FromDays(1)");

            foreach (var book in books)
            {
                BorrowBook(book,borrowInterval);
            }

            EventRaiser.RaiseEvent(new BookBorrowedProcessEvent.BookBorrowedProcessCreatedEvent(this));
        }

        private void BorrowBook(Book.Book book,TimeSpan borrowInterval)
        {
            if (book.Number <= 0)
            {
                throw new BookNotEnoughException($"book:{book.Name} is not enough");
            }

            if(BookBorrowedRecords.Any(x=>x.Book.ISBN==book.ISBN))
            {
                throw new BorrowSameBookTwiceException($"already have borrowed record for book:{book.Name}");
            }

            book.Borrow();
            var record = new BorrowedRecord(this,UserId, book, borrowInterval);
            BookBorrowedRecords.Add(record);
        }

        public void ReturnBook(Book.Book book)
        {
            Contract.Requires(book != null, "book!=null");

            if (BookBorrowedRecords.None(x => x.Book.ISBN == book.ISBN))
            {
                throw new DomainException($"Did not borrowed book:{book.Name}");
            }

            var borrowRecord = BookBorrowedRecords.Single(x => x.Book.Id == book.Id);

            book.Return();

            var record=new ReturnedRecord(this,UserId, book,borrowRecord);
            BookReturnedRecords.Add(record);

            EventRaiser.RaiseEvent(new BookBorrowedProcessEvent.BookBorrowedProcessUpdatedEvent(this));
        }
    }
}