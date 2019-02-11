﻿using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITNews.Data.Repositories.Repositories
{
    public class PostTagRepository : IPostTagRepository, IDisposable
    {
        private ApplicationDbContext context;

        public PostTagRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public bool FindNotUsedTag (int tagId)
        {
            var notUsedTag = context.PostsTags.Where(x => x.TagId == tagId).FirstOrDefault();

            if (notUsedTag == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<int> GetPostTags(int postId)
        {
            var postTags = context.PostsTags.Where(x => x.PostId == postId).ToList();

            List<int> tagsId = new List<int>();

            foreach (var item in postTags)
            {
                tagsId.Add(item.TagId);
            }

            return tagsId;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
