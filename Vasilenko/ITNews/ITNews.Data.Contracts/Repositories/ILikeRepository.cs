using ITNews.Data.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Repositories
{
    public interface ILikeRepository: IDisposable
    {
        IEnumerable<Like> GetLikes(int postId, int commentId);

        void Save();
    }
}
