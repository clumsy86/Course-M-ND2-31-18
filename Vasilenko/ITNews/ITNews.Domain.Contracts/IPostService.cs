using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Contracts
{
    public interface IPostService
    {
        IEnumerable<PostDomainModel> GetPostsByUserId(string userId);

        IEnumerable<PostDomainModel> GetPosts();

        void UpdatePost(PostDomainModel post);

        void DeletePost(int postId);

        int CreatePost(PostDomainModel post, string userId);

        PostDomainModel FindPost(int postId);
    }
}
