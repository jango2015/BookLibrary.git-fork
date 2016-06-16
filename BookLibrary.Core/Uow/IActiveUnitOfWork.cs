using System;

namespace BookLibrary.Core.Uow
{
    public interface IActiveUnitOfWork
    {
        void RegisterCompleted(Action action);

        void RegisterDisposed(Action action);

        void RegisterFailed(Action action);
    }
}