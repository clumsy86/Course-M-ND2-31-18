using ITNews.Data.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Repositories
{
    public interface ICommentRepository : IDisposable
    {
        IEnumerable<Comment> GetComments(int postId);
       
        void Save();
    }
}
