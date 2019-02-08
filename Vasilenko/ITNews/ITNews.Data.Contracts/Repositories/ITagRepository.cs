using ITNews.Data.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Repositories
{
    public interface ITagRepository : IDisposable
    {
        IEnumerable<Tag> GetTags();

        void DeleteTags (int postId);

        void CreateTags(IEnumerable<Tag> tags, int postId);

        void Save();
    }
}
