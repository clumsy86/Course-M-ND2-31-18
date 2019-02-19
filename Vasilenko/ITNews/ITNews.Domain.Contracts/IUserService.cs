using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDomainModel> GetUsers();

        void UpdateUser(UserDomainModel user);

        void DeleteUser(string userId);

        string FindUsername(string userId);

        UserDomainModel FindUserById(string userId);
    }
}
