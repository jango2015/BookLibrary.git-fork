using System;

namespace BookLibrary.Core.Uow
{
    public interface IUnitOfWorkCompleteHandle:IDisposable
    {
        void Complete();
    }
}