using System;

namespace BookLibrary.Core
{
    public class BookLibraryException:ApplicationException
    {
        public BookLibraryException(string message):base(message)
        {
            
        }
    }
}