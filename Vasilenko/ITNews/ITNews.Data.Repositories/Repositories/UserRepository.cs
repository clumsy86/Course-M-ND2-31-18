using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITNews.Data.Repositories.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void DeleteUser(string userId)
        {
            var userDeleted = context.Users.Find(userId);
            context.Remove(userDeleted);
        }

        public ApplicationUser FindUser(string userId)
        {
            return context.Users.Where(x => x.Id == userId).FirstOrDefault();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public string FindUserName(string userId)
        {
            var user = context.Users.Where(x => x.Id == userId).FirstOrDefault();
            return user.UserName;
        }

        public void UpdateUser(ApplicationUser user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return context.Users.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
