using System;
using BookLibrary.Core.Event;
using BookLibrary.Core.ServiceBus;
using BookLibrary.DomainModel;
using BookLibrary.QueryModel;

namespace BookLibrary.QueryModelUpdater.User
{
    public class UserQueryModelDeletedUpdater:IMessageHandler<EntityDeletedEvent<UserModel>>
    {
        private readonly IQueryModelUpdaterSession _session;

        public UserQueryModelDeletedUpdater(IQueryModelUpdaterSession session)
        {
            _session = session;
        }

        public void Handle(EntityDeletedEvent<UserModel> message)
        {
            _session.Delete<UserQueryModel,Guid>(message.Entity.Id);
        }
    }
}