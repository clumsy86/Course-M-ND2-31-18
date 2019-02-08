using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITNews.Data.Repositories.Repositories
{
    public class TagRepository : ITagRepository, IDisposable
    {
        private ApplicationDbContext context;
        private IPostRepository postRepository;

        public TagRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void CreateTags(IEnumerable<Tag> tags, int postId)
        {
            var post = postRepository.FindPostByPostId(postId);
            if (post != null)
            {
                foreach (var item in tags)
                {
                    var tag = new Tag { Content = item.Content, Id = item.Id };
                    var tagPost = new PostTag
                    {
                        TagId = tag.Id,
                        PostId = post.Id
                    };
                }
            }
        }


        public void DeleteTags(int postId)
        {
            var post = postRepository.FindPostByPostId(postId);
         
            if (post != null)
            {
                var postTags = post.PostTags.Where(x => x.PostId == postId).ToList();
                if (postTags != null)
                {
                    foreach (var item in postTags)
                    {
                        context.PostsTags.Remove(item);
                    }
                }
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Tag> GetTags()
        {
            return context.Tags.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
