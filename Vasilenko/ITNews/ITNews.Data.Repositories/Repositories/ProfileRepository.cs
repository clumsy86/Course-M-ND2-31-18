using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Repositories.Repositories
{
    public class ProfileRepository : IProfileRepository, IDisposable
    {
        public void CreateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EditUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetUserById(string userId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
