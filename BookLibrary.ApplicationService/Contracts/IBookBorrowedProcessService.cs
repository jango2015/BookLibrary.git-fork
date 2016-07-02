﻿using System;
using System.Collections.Generic;
using BookLibrary.Domain.BookManageProcess;

namespace BookLibrary.ApplicationService.Contracts
{
    public interface IBookBorrowedProcessService:IApplicationService
    {
        void BorrowBooks(Guid userId, List<Guid> bookIds, TimeSpan borrowInterval);

        void ReturnBook(Guid userId, Guid bookId);
    }
}