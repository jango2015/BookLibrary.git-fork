using System;
using BookLibrary.Core.Event;
using BookLibrary.Core.ServiceBus;
using BookLibrary.Domain.Events.User;
using BookLibrary.QueryModel;

namespace BookLibrary.QueryModelUpdater.User
{
    public  class UserQueryModelUpdater : IHandleMessage<UserCreatedEvent>
    {
        private readonly IQueryModelUpdaterSession _session;

        public UserQueryModelUpdater(IQueryModelUpdaterSession session)
        {
            _session = session;
        }


        public void Handle(UserCreatedEvent message)
        {
            var queryModel = new UserQueryModel()
            {
                Id = message.Id,
                Name = message.Name,
                Email = message.Email,
                RegisterDateTime = message.RegisterDateTime,
                LastLoginDateTime = message.LastLoginDateTime
            };
            _session.Save(queryModel);
        }
    }


}
