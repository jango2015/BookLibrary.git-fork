using BookLibrary.Core.ServiceBus;
using BookLibrary.Domain.Events.BookLibraryProcess;
using BookLibrary.QueryModel;

namespace BookLibrary.QueryModelUpdater.BookLibraryProcess
{
    public class UserAndBookLibraryProcessMapperUpdater:IHandleMessage<BookLibraryProcessEvent.BookLibraryProcessCreatedEvent>
    {

        private readonly IQueryModelUpdaterSession _updaterSession;

        public UserAndBookLibraryProcessMapperUpdater(IQueryModelUpdaterSession updaterSession)
        {
            _updaterSession = updaterSession;
        }

        public void Handle(BookLibraryProcessEvent.BookLibraryProcessCreatedEvent message)
        {
            var index = UserAndLibraryProcessMapper.Index(message.UserId);
            _updaterSession.AddItemToSet(index,message.BookLibraryProcessId.ToString());
        }
    }
}