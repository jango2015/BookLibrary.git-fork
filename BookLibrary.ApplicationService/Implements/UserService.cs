using System;
using System.Linq;
using BookLibrary.ApplicationService.Contracts;
using BookLibrary.ApplicationService.Exceptions;
using BookLibrary.Core;
using BookLibrary.Core.ServiceBus;
using BookLibrary.Core.Uow;
using BookLibrary.Domain.User;
using BookLibrary.DomainModel;
using BookLibrary.Repository.Contracts;

namespace BookLibrary.ApplicationService.Implements
{
    public class UserService : ApplicationService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailUniqueChecker _emailUniqueChecker;
        private readonly EntityChangedEventRaiser _eventRaiser;

        public UserService(IRepositoryContext context, IUserRepository userRepository,IEmailUniqueChecker emailUniqueChecker,EntityChangedEventRaiser eventRaiser)
          : base(context)
        {
            _userRepository = userRepository;
            _emailUniqueChecker = emailUniqueChecker;
            _eventRaiser = eventRaiser;
        }

        public Guid Register(UserModel userModel)
        {
            var user = User.Register(userModel, _emailUniqueChecker,_eventRaiser);
            _userRepository.Add(user);

            return user.Id;
        }

        public bool Login(string email, string password)
        {
            var user = _userRepository.Find(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
            if (user == null)
            {
                throw  new ApplicationServiceException("no such user");
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

            user.ChangePassword(originalPassword,newPassword);

            _userRepository.Update(user);
        }

        public User GetUser(Guid id)
        {
            var user = _userRepository.Get(id);

            return user;
        }
    }
}