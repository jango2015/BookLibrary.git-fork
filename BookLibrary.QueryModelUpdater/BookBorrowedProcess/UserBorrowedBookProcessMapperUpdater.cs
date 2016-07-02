using BookLibrary.Core.ServiceBus;
using BookLibrary.Domain.Events.BookBorrowedProcess;

namespace BookLibrary.QueryModelUpdater.BookBorrowedProcess
{
    public class UserBorrowedBookProcessMapperUpdater:IHandleMessage<BookBorrowedProcessCreatedEvent>
    {
        private readonly IQueryModelUpdaterSession _updaterSession;

        public UserBorrowedBookProcessMapperUpdater(IQueryModelUpdaterSession updaterSession)
        {
            _updaterSession = updaterSession;
        }

        public void Handle(BookBorrowedProcessCreatedEvent message)
        {
            
        }
    }
}