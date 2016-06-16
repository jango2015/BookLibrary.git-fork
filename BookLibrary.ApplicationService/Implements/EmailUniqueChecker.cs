using System.Linq;
using BookLibrary.Domain.User;
using BookLibrary.Repository.Contracts;

namespace BookLibrary.ApplicationService.Implements
{
    public class EmailUniqueChecker:IEmailUniqueChecker
    {
        private readonly IUserRepository _userRepository;

        public EmailUniqueChecker(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsExist(string email)
        {
            var user = _userRepository.Find(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();

            return user != null;
        }
    }
}