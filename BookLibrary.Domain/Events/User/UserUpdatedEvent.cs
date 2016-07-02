using System;
using BookLibrary.Core.Event;

namespace BookLibrary.Domain.Events.User
{
    public class UserUpdatedEvent:IEntityUpdatedEvent,IBookLibraryEvent
    {
        [Obsolete("for serilization")]
        public UserUpdatedEvent() { }

        public UserUpdatedEvent(Domain.User.User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            RegisterDateTime = user.RegisterDateTime;
            LastLoginDateTime = user.LastLoginDateTime;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime RegisterDateTime { get; private set; }

        public DateTime LastLoginDateTime { get; private set; }
    }
}