using AutoMapper;
using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
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
        public void CreateTags(IEnumerable<TagDomainModel> tagsDomainModel, int postId)
        {
            var tags = mapper.Map<List<Tag>>(tagsDomainModel);
            tagRepository.CreateTags(tags, postId);
            tagRepository.Save();
        }

        public void DeleteTags(int postId)
        {
            tagRepository.DeleteTags(postId);
            tagRepository.Save();
        }

        public IEnumerable<TagDomainModel> GetTags()
        {
            var tags = tagRepository.GetTags();
            var tagsDomainModel = mapper.Map<List<TagDomainModel>>(tags);
            return tagsDomainModel;
        }
    }
}
