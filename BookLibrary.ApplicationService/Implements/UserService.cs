using System;
using System.Linq;
using BookLibrary.ApplicationService.Contracts;
using BookLibrary.ApplicationService.Exceptions;
using BookLibrary.Core;
using BookLibrary.Core.ServiceBus;
using BookLibrary.Core.Uow;
using BookLibrary.DomainModel;
using BookLibrary.DomainService.Contracts;

namespace BookLibrary.ApplicationService.Implements
{
    public class UserService :  IUserService
    {
        private readonly IUserDomainService _userDomainService;

        public UserService(IUserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }

        public Guid Register(UserModel userModel)
        {
            return _userDomainService.Register(userModel);
        }

        public bool Login(string email, string password)
        {
            return _userDomainService.Login(email, password);
        }

        public void ChangePassword(Guid id, string originalPassword, string newPassword)
        {
             _userDomainService.ChangePassword(id, originalPassword,newPassword);
        }
    }
}