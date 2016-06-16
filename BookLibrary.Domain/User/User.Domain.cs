using System;
using System.Diagnostics.Contracts;
using BookLibrary.Core.Extensions;
using BookLibrary.Domain.Exceptions;
using BookLibrary.Model;

namespace BookLibrary.Domain.User
{
    public partial class User
    {
        public static User Register(UserModel userModel, IEmailUniqueChecker emailUniqueChecker)
        {
            Contract.Requires(!userModel.Name.IsNullOrEmpty(), "invalid username");

            if (emailUniqueChecker.IsExist(userModel.Email))
            {
                throw new DuplicateEmailException("email already exist, please input another one");
            }

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
            
            return user;
        }

        public bool Login(string password)
        {
            Contract.Requires(!password.IsNullOrEmpty(), "password can not be empty");

            var hashedPassword = new Password(Password, Salt);
            if (hashedPassword.IsCorrectPassword(password))
            {
                LastLoginDateTime = DateTime.Now;
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
        }
    }
}