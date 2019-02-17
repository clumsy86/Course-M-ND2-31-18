using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Contracts
{
    public interface IPostService
    {
        IEnumerable<PostDomainModel> GetPostsByUserId(string userId);

        IEnumerable<PostDomainModel> GetPosts();

        void UpdatePost(PostDomainModel post, string userId);

        void DeletePost(int postId);

        int CreatePost(PostDomainModel post, string userId);

        PostDomainModel FindPost(int postId);

        IEnumerable<PostDomainModel> GetPublishedPosts();

        IEnumerable<PostDomainModel> GetPostsById(int postId);

        IEnumerable<PostDomainModel> GetPopularPosts();

        IEnumerable<SearchDomainModel> Search(string search);
    }
}
