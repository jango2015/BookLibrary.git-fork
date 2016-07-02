using BookLibrary.Core.ServiceBus;
using BookLibrary.Domain.Events.BookBorrowedProcess;

namespace BookLibrary.QueryModelUpdater.BookBorrowedProcess
{
    public class UserBorrowedBookProcessMapperUpdater:IHandleMessage<BookBorrowedProcessEvent.BookBorrowedProcessCreatedEvent>
    {
        private readonly IQueryModelUpdaterSession _updaterSession;

        public UserBorrowedBookProcessMapperUpdater(IQueryModelUpdaterSession updaterSession)
        {
            _updaterSession = updaterSession;
        }

        public void Handle(BookBorrowedProcessEvent.BookBorrowedProcessCreatedEvent message)
        {
            
        }
    }
}