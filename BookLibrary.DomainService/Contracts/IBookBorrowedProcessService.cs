﻿using System;
using System.Collections.Generic;
using BookLibrary.Domain.BookManageProcess;

namespace BookLibrary.DomainService.Contracts
{
    public interface IBookBorrowedProcessService:IDomainService
    {
        BookBorrowedProcess GetBookBorrowedProcess(Guid bookBorrowedProcessId);

        void BorrowBooks(Guid userId, List<Guid> bookIds, TimeSpan borrowInterval);

        void ReturnBook(Guid userId, Guid bookId);
    }
}