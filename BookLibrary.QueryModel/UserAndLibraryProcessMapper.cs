using System;
using System.Collections.Generic;

namespace BookLibrary.QueryModel
{
    public class UserAndLibraryProcessMapper
    {
        public static string Index(Guid userId)
        {
            return "urn:user>bookLibraryProcess:" + userId;
        }
    }
}