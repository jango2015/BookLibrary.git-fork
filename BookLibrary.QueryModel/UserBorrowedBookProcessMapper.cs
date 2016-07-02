using System;
using System.Collections.Generic;

namespace BookLibrary.QueryModel
{
    public class UserBorrowedBookProcessMapper
    {
        public static string Index(Guid userId)
        {
            return "urn:user>borrowedBookProcess:" + userId;
        }
    }
}