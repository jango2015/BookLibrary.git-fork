using System;
using System.Collections.Generic;
using BookLibrary.QueryModel;
using BookLibrary.QueryModelReader.Contracts;

namespace BookLibrary.QueryModelReader.Implements
{
    public class BookBorrowedProcessQueryReader : QueryReader, IBookBorrowedProcessQueryReader
    {
        public BookBorrowedProcessQueryReader(IQueryModelReaderSession session) : base(session)
        {
        }

        public BorrowedBookProcessModel Get(Guid id)
        {
            return Session.Get<BorrowedBookProcessModel,Guid>(id);
        }

        public List<BorrowedBookProcessModel> GetByUserId(Guid userId)
        {
            var index = UserBorrowedBookProcessMapper.Index(userId);
            var ids = Session.GetAllItems(index);

            var models = Session.GetByIds<BorrowedBookProcessModel>(ids);
            return models;
        }

       
    }
}