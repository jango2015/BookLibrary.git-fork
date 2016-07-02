using BookLibrary.Core.ServiceBus;
using BookLibrary.Domain.Events.BookBorrowedProcess;
using BookLibrary.QueryModel;

namespace BookLibrary.QueryModelUpdater.BookBorrowedProcess
{
    public class BookBorrowedProcessQueryModelUpdater:IHandleMessage<BookBorrowedProcessCreatedEvent>
    {
        private readonly IQueryModelUpdaterSession _updaterSession;

        public BookBorrowedProcessQueryModelUpdater(IQueryModelUpdaterSession updaterSession)
        {
            _updaterSession = updaterSession;
        }

        public void Handle(BookBorrowedProcessCreatedEvent message)
        {
            var model = new BorrowedBookProcessModel(message);

            _updaterSession.Save(model);
        }
    }
}