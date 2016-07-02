﻿using System;
using BookLibrary.Core.Event;

namespace BookLibrary.Domain.Events.User
{
    public class UserUpdatedEvent:IEntityUpdatedEvent,IBookLibraryEvent
    {
        [Obsolete("for serilization")]
        public UserUpdatedEvent() { }

        public UserUpdatedEvent(Guid id, string name, string email, DateTime registerDateTime, DateTime lastLoginDateTime)
        {
            Id = id;
            Name = name;
            Email = email;
            RegisterDateTime = registerDateTime;
            LastLoginDateTime = lastLoginDateTime;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime RegisterDateTime { get; private set; }

        public DateTime LastLoginDateTime { get; private set; }
    }
}