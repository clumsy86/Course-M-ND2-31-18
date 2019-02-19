using ITNews.Data.Contracts.Entities;
using System;

namespace ITNews.Data.Contracts.Repositories
{
    public interface IProfileRepository: IDisposable
    {
        void EditProfile (Profile profile);

        void CreateProfile(Profile profile, string userId);

        void Save();

        Profile FindProfile(string userId);
    }
}
