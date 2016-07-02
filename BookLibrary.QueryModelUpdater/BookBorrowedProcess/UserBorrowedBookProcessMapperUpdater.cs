using System;
using BookLibrary.Core.ServiceBus;
using BookLibrary.Domain.Events.BookBorrowedProcess;
using BookLibrary.QueryModel;

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
            var index = UserBorrowedBookProcessMapper.Index(message.UserId);
            _updaterSession.AddItemToSet(index,message.BookBorrowedProcessId.ToString());
        }
    }
}