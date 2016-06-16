using BookLibrary.Domain.User;
using BookLibrary.Repository.Contracts;
using BookLibrary.Repository.EntityFramework;

namespace BookLibrary.Repository.Implements
{
    public class UserRepository : EntityFrameworkRepository<User>, IUserRepository
    {
        public UserRepository(IEntityFrameworkContext efContext)
          : base(efContext)
        {
        }
    }
}