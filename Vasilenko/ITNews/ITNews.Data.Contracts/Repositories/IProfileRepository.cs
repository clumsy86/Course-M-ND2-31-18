using ITNews.Data.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Repositories
{
    public interface IProfileRepository: IDisposable
    {
        IEnumerable<ApplicationUser> GetUserById(string userId);

        void EditUser (ApplicationUser user);

      //  void DeleteUser(string userId);

        void CreateUser(ApplicationUser user);

        void Save();

    }
}
