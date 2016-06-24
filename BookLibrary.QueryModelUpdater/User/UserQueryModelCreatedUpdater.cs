using System;
using BookLibrary.Core.Event;
using BookLibrary.Core.ServiceBus;
using BookLibrary.Domain.Events;
using BookLibrary.QueryModel;

namespace BookLibrary.QueryModelUpdater.User
{
    public  class UserQueryModelCreatedUpdater : IMessageHandler<UserCreatedEvent>
    {
        private readonly IQueryModelUpdaterSession _session;

        public UserQueryModelCreatedUpdater(IQueryModelUpdaterSession session)
        {
            _session = session;
        }


        public void Handle(UserCreatedEvent message)
        {
            var queryModel = new UserQueryModel()
            {
                Id = message.User.Id,
                Name = message.User.Name,
                Email = message.User.Email,
                RegisterDateTime = message.User.RegisterDateTime
            };
            _session.Save(queryModel);
        }
    }


}
