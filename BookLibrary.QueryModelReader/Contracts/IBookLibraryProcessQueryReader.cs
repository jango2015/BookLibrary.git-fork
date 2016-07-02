using System;
using System.Collections.Generic;
using BookLibrary.QueryModel;

namespace BookLibrary.QueryModelReader.Contracts
{
    public interface IBookLibraryProcessQueryReader
    {
        BookLibraryProcessModel Get(Guid id);

        List<BookLibraryProcessModel> GetByUserId(Guid userId);
    }
}