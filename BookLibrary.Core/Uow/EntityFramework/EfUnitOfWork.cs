using System;
using System.Data.Entity;
using System.Transactions;

namespace BookLibrary.Core.Uow.EntityFramework
{
    public class EfUnitOfWork:IUnitOfWork
    {
        private readonly DefaultUnitOfWorkOptions _defaultUnitOfWorkOptions;
        private readonly DbContext _dbContext;
        private TransactionScope _transactionScope;
        private Action _completed;
        private Action _disposed;
        private Action _failed;
        public string Id { get; }

        public EfUnitOfWork(DefaultUnitOfWorkOptions defaultUnitOfWorkOptions,DbContext dbContext)
        {
            _defaultUnitOfWorkOptions = defaultUnitOfWorkOptions;
            _dbContext = dbContext;
            Id = Guid.NewGuid().ToString("n");
        }

        public void Begin(UnitOfWorkOptions options)
        {
            _transactionScope = new TransactionScope(
                options.TransactionScopeOption.GetValueOrDefault(_defaultUnitOfWorkOptions.TransactionScopeOption),
                new TransactionOptions()
                {
                    IsolationLevel = options.IsolationLevel.GetValueOrDefault(_defaultUnitOfWorkOptions.IsolationLevel),
                    Timeout = options.Timeout.GetValueOrDefault(_defaultUnitOfWorkOptions.Timeout)
                });
        }

        public void Dispose()
        {
            _transactionScope.Dispose();
            _disposed?.Invoke();
        }

        public void Complete()
        {
            try
            {
                _dbContext.SaveChanges();
                _transactionScope?.Complete();

                _completed?.Invoke();
            }
            catch
            {
                _failed?.Invoke();
                throw;
            }
           
        }

        public void RegisterCompleted(Action action)
        {
            _completed = action;
        }

        public void RegisterDisposed(Action action)
        {
            _disposed = action;
        }

        public void RegisterFailed(Action action)
        {
            _failed = action;
        }
    }
}