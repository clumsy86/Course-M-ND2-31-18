﻿using ITNews.Data.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Repositories
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<ApplicationUser> GetUsers();

        void UpdateUser(ApplicationUser user);

        void DeleteUser(string userId);

        void Save();

        string FindUserName(string userId);

        ApplicationUser FindUser(string userId);

        void LockUser(string userId, bool block);
    }
}
