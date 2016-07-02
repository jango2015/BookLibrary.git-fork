using System;
using System.Linq;
using BookLibrary.Core;
using BookLibrary.Domain.Exceptions;
using BookLibrary.Domain.User;
using BookLibrary.DomainModel;
using BookLibrary.DomainService.Contracts;
using BookLibrary.DomainService.Exceptions;
using BookLibrary.Repository.Contracts;

namespace BookLibrary.DomainService.Implements
{
    public class UserDomainService:IUserDomainService
    {
        private readonly IUserRepository _userRepository;

        public UserDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Guid Register(UserModel userModel)
        {
            var existedUser = _userRepository.Find(x => x.Email.ToLower() == userModel.Email.ToLower()).FirstOrDefault();
            if (existedUser!=null)
            {
                throw new DuplicateEmailException("email already exist, please input another one");
            }

            var user = User.Register(userModel);
            _userRepository.Add(user);

            return user.Id;
        }

        public bool Login(string email, string password)
        {
            var user = _userRepository.Find(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
            if (user == null)
            {
                throw new DomainServiceException("no such user");
            }
            if (!user.Login(password))
            {
                return false;
            }

            _userRepository.Update(user);

            return true;
        }

        public void ChangePassword(Guid id, string originalPassword, string newPassword)
        {
            var user = _userRepository.Get(id);

            user.ChangePassword(originalPassword, newPassword);

            _userRepository.Update(user);
        }
    }
}