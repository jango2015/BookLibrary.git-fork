using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookLibrary.Core
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        IRepositoryContext Context { get; }

        TAggregateRoot Get(Guid key);

        void Add(TAggregateRoot aggregateRoot);

        void Update(TAggregateRoot aggregateRoot);

        void Remove(TAggregateRoot aggregateRoot);

        IEnumerable<TAggregateRoot> GetAll();

        IEnumerable<TAggregateRoot> Find(Expression<Func<TAggregateRoot, bool>> conditions);
    }
}