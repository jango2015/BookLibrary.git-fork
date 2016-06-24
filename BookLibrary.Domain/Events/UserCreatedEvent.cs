using BookLibrary.Core.Event;

namespace BookLibrary.Domain.Events
{
    public class UserCreatedEvent:IEntityCreatedEvent
    {
        public UserCreatedEvent(User.User user)
        {
            User = user;
        }
        public User.User User { get; }
    }
}