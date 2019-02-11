using ITNews.Data.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Repositories
{
    public interface IPostRepository: IDisposable
    {
        IEnumerable<Post> GetPostsByUserId(string userId);

        IEnumerable<Post> GetPostsOrderByRating();

        void UpdatePost (Post post);

        void DeletePost(int postId);

        void CreatePost(Post post, string userId);

        Post FindPostByPostId(int postId);

        void Save();

        int GetPostId(Post post);
    }
}
