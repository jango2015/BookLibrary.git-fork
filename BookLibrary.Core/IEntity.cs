using System;

namespace BookLibrary.Core
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}