using System;
using System.Collections.Generic;
using BookLibrary.QueryModel;
using BookLibrary.QueryModelReader.Contracts;

namespace BookLibrary.QueryModelReader.Implements
{
    public class BookLibraryProcessQueryReader : QueryReader, IBookLibraryProcessQueryReader
    {
        public BookLibraryProcessQueryReader(IQueryModelReaderSession session) : base(session)
        {
        }

        public BookLibraryProcessModel Get(Guid id)
        {
            return Session.Get<BookLibraryProcessModel,Guid>(id);
        }

        public List<BookLibraryProcessModel> GetByUserId(Guid userId)
        {
            var index = UserAndLibraryProcessMapper.Index(userId);
            var ids = Session.GetAllItems(index);

            var models = Session.GetByIds<BookLibraryProcessModel>(ids);
            return models;
        }

       
    }
}