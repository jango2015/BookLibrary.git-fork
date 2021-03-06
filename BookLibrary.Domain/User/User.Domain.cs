﻿using System;
using System.Diagnostics.Contracts;
using BookLibrary.Core.Extensions;
using BookLibrary.Core.ServiceBus;
using BookLibrary.Domain.Events.User;
using BookLibrary.Domain.Exceptions;
using BookLibrary.DomainModel;

namespace BookLibrary.Domain.User
{
    public partial class User
    {
        public static User Register(UserModel userModel)
        {
            Contract.Requires(!userModel.Name.IsNullOrEmpty(), "invalid username");

            var password=new Password(userModel.Password);

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = userModel.Name,
                Password = password.HashedPassword,
                Salt = password.Salt,
                Email = userModel.Email,
                RegisterDateTime = DateTime.Now,
                LastLoginDateTime = DateTime.Now
            };

            EventRaiser.RaiseEvent(new UserEvent.UserCreatedEvent(user));
            
            return user;
        }

        public bool Login(string password)
        {
            Contract.Requires(!password.IsNullOrEmpty(), "password can not be empty");

            var hashedPassword = new Password(Password, Salt);
            if (hashedPassword.IsCorrectPassword(password))
            {
                LastLoginDateTime = DateTime.Now;

                EventRaiser.RaiseEvent(new UserEvent.UserUpdatedEvent(this));

                return true;
            }

            return false;
        }

        public void ChangePassword(string originalPassword, string newPassword)
        {
            Contract.Requires(!originalPassword.IsNullOrEmpty(), "password can not be empty");

            var hashedPassword = new Password(Password, Salt);
            if (!hashedPassword.IsCorrectPassword(originalPassword))
            {
                throw new OriginalPasswordIsWrongException("original password is wrong!");
            }
            var newHashedPassword = new Password(newPassword);
            Password = newHashedPassword.HashedPassword;
            Salt = newHashedPassword.Salt;

            //ignore password updated event
        }
    }
}