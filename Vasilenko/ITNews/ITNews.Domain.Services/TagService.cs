using AutoMapper;
using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Domain.Services
{
    public class TagService : ITagService
    {
        private ITagRepository tagRepository;
        private IMapper mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            this.tagRepository = tagRepository;
            this.mapper = mapper;
        }
        public void AddTags (string tags, int postId)
        {
            if (tags.Contains(','))
            {
                var words = tags.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in words)
                {                    
                    var tagId = tagRepository.FindTag(item);

                    if (tagId == 0)
                    {
                        var newTag = new Tag { Content = item };

                        tagRepository.CreateTag(newTag);

                        tagRepository.Save();

                        var newTagId = tagRepository.GetNewTagId(newTag);

                        tagRepository.AddToPost(postId, newTagId);
                    }
                    else
                    {
                        tagRepository.AddToPost(postId, tagId);
                    }

                    tagRepository.Save();
                }
            }
            else
            {
                var tagId = tagRepository.FindTag(tags);

                if (tagId == 0)
                {
                    var newTag = new Tag { Content = tags };

                    tagRepository.CreateTag(newTag);

                    tagRepository.Save();

                    var newTagId = tagRepository.GetNewTagId(newTag);

                    tagRepository.AddToPost(postId, newTagId);
                }
                else
                {
                    tagRepository.AddToPost(postId, tagId);
                }

                tagRepository.Save();
            }
        }


        public IEnumerable<TagDomainModel> GetTags()
        {
            var tags = tagRepository.GetTags();

            var tagsDomainModel = mapper.Map<List<TagDomainModel>>(tags);

            return tagsDomainModel;
        }     
    }
}
