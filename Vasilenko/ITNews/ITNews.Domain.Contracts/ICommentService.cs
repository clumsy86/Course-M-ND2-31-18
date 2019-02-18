using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Contracts
{
    public interface ICommentService
    {
        void Create(string message, int postId, string userId);

        List<CommentDomainModel> GetComments(int postId);

        int GetCommentsCount(int postId);
    }
}
