using AutoMapper;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;


namespace ITNews.Domain.Services
{
    public class PostTagService : IPostTagService
    {
        private IPostTagRepository postTagRepository;
        private IMapper mapper;

        public PostTagService(IMapper mapper, IPostTagRepository postTagRepository)
        {
            this.mapper = mapper;
            this.postTagRepository = postTagRepository;
        }
        public IEnumerable<PostTagDomainModel> GetPostsTags()
        {
            var postsTags =postTagRepository.GetPostsTags();
            var postsTagsDomainModel = mapper.Map<List<PostTagDomainModel>>(postsTags);
            return postsTagsDomainModel;
        }

        public IEnumerable<PostTagDomainModel> GetPostsByTagId(int tagId)
        {
            var postsTags = postTagRepository.PostsByTagId(tagId);
            var postsTagsDomainModel = mapper.Map<List<PostTagDomainModel>>(postsTags);
            return postsTagsDomainModel;
        }
    }
}
