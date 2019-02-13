using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITNews.Data.Repositories.Repositories
{
    public class PostRepository : IPostRepository, IDisposable
    {
        private ApplicationDbContext context;

        public PostRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void DeletePost(int postId)
        {
            var postDeleted = context.Posts.Find(postId);
            context.Remove(postDeleted);
        }

        public IEnumerable<Post> GetPublishedPosts()
        {
            return context.Posts.Include(x=>x.Category).Include(x=>x.User).Where(x => x.Published == true).OrderByDescending(x=>x.Created).ToList();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Post> GetPostsByUserId(string userId)
        {
            return context.Posts.ToList().Where(x=>x.UserId==userId);
        }

        public IEnumerable<Post> GetPostsOrderByRating()
        {
            return context.Posts.Include(x=>x.Category).ToList().OrderByDescending(x => x.Rating);
        }

        public Post FindPostByPostId (int postId)
        {
            return context.Posts.Find (postId);
        }

        public void CreatePost(Post post, string userId)
        {
            context.Posts.Attach(post);
            post.UserId = userId;
        }

        public int GetPostId(Post post)
        {
            context.Entry(post).GetDatabaseValues();
            return post.Id;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            context.Entry(post).State = EntityState.Modified;
        }   
    }
}
