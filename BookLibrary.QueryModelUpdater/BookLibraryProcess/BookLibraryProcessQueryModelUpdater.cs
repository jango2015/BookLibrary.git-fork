using BookLibrary.Core.ServiceBus;
using BookLibrary.Domain.Events.BookLibraryProcess;
using BookLibrary.QueryModel;

namespace BookLibrary.QueryModelUpdater.BookLibraryProcess
{
    public class BookLibraryProcessQueryModelUpdater:
        IHandleMessage<BookLibraryProcessEvent.BookLibraryProcessCreatedEvent>,
        IHandleMessage<BookLibraryProcessEvent.BookLibraryProcessUpdatedEvent>
    {
        private readonly IQueryModelUpdaterSession _updaterSession;

        public BookLibraryProcessQueryModelUpdater(IQueryModelUpdaterSession updaterSession)
        {
            _updaterSession = updaterSession;
        }

        public void Handle(BookLibraryProcessEvent.BookLibraryProcessCreatedEvent message)
        {
            var model = new BookLibraryProcessModel(message);

            _updaterSession.Save(model);
        }

        public void Handle(BookLibraryProcessEvent.BookLibraryProcessUpdatedEvent message)
        {
            var model = new BookLibraryProcessModel(message);

            _updaterSession.Save(model);
        }
    }
}