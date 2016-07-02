using System;
using System.Collections.Generic;

namespace BookLibrary.QueryModel
{
    public class UserBorrowedBookProcessMapper
    {
        public UserBorrowedBookProcessMapper()
        {
            Mappers=new List<Mapper>();
        }

        public List<Mapper> Mappers { get; set; } 

        public class Mapper
        {
            public Guid UserId { get; set; }
            public Guid BorrowedBookProcessId { get; set; }
            public DateTime BorrowedDate { get; set; }
        }
    }
}