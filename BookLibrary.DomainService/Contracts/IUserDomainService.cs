using System;
using BookLibrary.DomainModel;

namespace BookLibrary.DomainService.Contracts
{
    public interface IUserDomainService:IDomainService
    {
        Guid Register(UserModel userModel);

        bool Login(string email, string password);

        void ChangePassword(Guid id, string originalPassword, string newPassword);
    }
}