using BookLibrary.Core.ServiceBus;
using BookLibrary.Domain.Events.BookBorrowedProcess;
using BookLibrary.QueryModel;

namespace BookLibrary.QueryModelUpdater.BookBorrowedProcess
{
    public class BookBorrowedProcessQueryModelUpdater:
        IHandleMessage<BookBorrowedProcessEvent.BookBorrowedProcessCreatedEvent>,
        IHandleMessage<BookBorrowedProcessEvent.BookBorrowedProcessUpdatedEvent>
    {
        private readonly IQueryModelUpdaterSession _updaterSession;

        public BookBorrowedProcessQueryModelUpdater(IQueryModelUpdaterSession updaterSession)
        {
            _updaterSession = updaterSession;
        }

        public void Handle(BookBorrowedProcessEvent.BookBorrowedProcessCreatedEvent message)
        {
            var model = new BorrowedBookProcessModel(message);

            _updaterSession.Save(model);
        }

        public void Handle(BookBorrowedProcessEvent.BookBorrowedProcessUpdatedEvent message)
        {
            var model = new BorrowedBookProcessModel(message);

            _updaterSession.Save(model);
        }
    }
}