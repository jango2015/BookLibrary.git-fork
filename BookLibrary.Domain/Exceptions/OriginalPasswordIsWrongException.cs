﻿namespace BookLibrary.Domain.Exceptions
{
    public class OriginalPasswordIsWrongException:DomainException
    {
        public OriginalPasswordIsWrongException(string message) : base(message)
        {
        }
    }
}