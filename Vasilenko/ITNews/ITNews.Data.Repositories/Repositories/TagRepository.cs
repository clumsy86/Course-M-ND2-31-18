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
            post.
            foreach (var item in tags)
            {
                context.Tags.Add(item);
            }
        }

        public void DeleteTag(int tagId, int postId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Tag> GetTags(string keyword)
        {
            return context.Tags.Where(x => x.Content.Contains(keyword)).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
