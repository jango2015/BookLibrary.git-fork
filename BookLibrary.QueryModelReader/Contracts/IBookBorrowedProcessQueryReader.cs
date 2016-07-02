using System;
using System.Collections.Generic;
using BookLibrary.QueryModel;

namespace BookLibrary.QueryModelReader.Contracts
{
    public interface IBookBorrowedProcessQueryReader
    {
        BorrowedBookProcessModel Get(Guid id);

        List<BorrowedBookProcessModel> GetByUserId(Guid userId);
    }
}