﻿using System;
using System.Transactions;

namespace BookLibrary.Core.Uow
{
    public class DefaultUnitOfWorkOptions
    {
        public TransactionScopeOption TransactionScopeOption => TransactionScopeOption.Required;

        public IsolationLevel IsolationLevel=>IsolationLevel.ReadUncommitted;

        public TimeSpan Timeout=>TimeSpan.FromMinutes(1);
    }
}