using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Repositories.Repositories
{
    public class LikeRepository : ILikeRepository, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Like> GetLikes(int postId, int commentId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
