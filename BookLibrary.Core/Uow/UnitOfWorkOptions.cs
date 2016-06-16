using System;
using System.Transactions;

namespace BookLibrary.Core.Uow
{
    public class UnitOfWorkOptions
    {
        public TimeSpan? Timeout { get; set; }

        public TransactionScopeOption? TransactionScopeOption { get; set; }

        public IsolationLevel? IsolationLevel { get; set; }
    }
}