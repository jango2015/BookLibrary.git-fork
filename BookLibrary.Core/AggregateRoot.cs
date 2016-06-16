using System;

namespace BookLibrary.Core
{
    public class AggregateRoot<TAggregate> : IAggregateRoot
        where TAggregate : AggregateRoot<TAggregate>
    {
        public Guid Id { get; protected set; }
    }
}