using BookLibrary.Core.Event;
using BookLibrary.Core.ServiceBus;
using BookLibrary.DomainModel;
using BookLibrary.QueryModel;

namespace BookLibrary.QueryModelUpdater.User
{
    public partial class UserQueryModelCreatedUpdater : IMessageHandler<EntityCreatedEvent<UserModel>>
    {
        private readonly IQueryModelUpdaterSession _session;

        public UserQueryModelCreatedUpdater(IQueryModelUpdaterSession session)
        {
            _session = session;
        }

        public void Handle(EntityCreatedEvent<UserModel> message)
        {
            var queryModel = new UserQueryModel()
            {
                Id = message.Entity.Id,
                Name = message.Entity.Name,
                Email = message.Entity.Email,
                RegisterDateTime = message.Entity.RegisterDateTime
            };
            _session.Save(queryModel);
        }
    }


}
