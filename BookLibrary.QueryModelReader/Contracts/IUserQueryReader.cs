using System;
using System.Collections.Generic;
using BookLibrary.QueryModel;

namespace BookLibrary.QueryModelReader.Contracts
{
    public interface IUserQueryReader
    {
        UserQueryModel Get(Guid id);

    }
}