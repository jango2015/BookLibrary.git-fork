using System;
using BookLibrary.Domain.User;
using BookLibrary.DomainModel;

namespace BookLibrary.ApplicationService.Contracts
{
    public interface IUserService : IApplicationService
    {
        Guid Register(UserModel userModel);

        bool Login(string email, string password);

        void ChangePassword(Guid id, string originalPassword, string newPassword);

        User GetUser(Guid id);
    }
}