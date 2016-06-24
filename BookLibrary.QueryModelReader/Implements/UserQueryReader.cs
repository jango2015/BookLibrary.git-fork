using System;
using BookLibrary.QueryModel;
using BookLibrary.QueryModelReader.Contracts;

namespace BookLibrary.QueryModelReader.Implements
{
    public class UserQueryReader:QueryReader,IUserQueryReader
    {
        public UserQueryReader(IQueryModelReaderSession session) : base(session)
        {
        }

        public UserQueryModel Get(Guid id)
        {
           var model= Session.Get<UserQueryModel,Guid>(id);
            return model;
        }
    }
}