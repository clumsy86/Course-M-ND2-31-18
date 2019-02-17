using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ITNews.Data.Repositories.Repositories
{
    public class ProfileRepository : IProfileRepository, IDisposable
    {
        private ApplicationDbContext context;

        public ProfileRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreateProfile(Profile profile, string userId)
        {
            context.Profiles.Attach(profile);
            profile.UserId = userId;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Profile FindProfile(string userId)
        {
            return context.Profiles.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public void EditProfile(Profile profile, string userId)
        {
            context.Entry(profile).State = EntityState.Modified;
            profile.UserId = userId;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
