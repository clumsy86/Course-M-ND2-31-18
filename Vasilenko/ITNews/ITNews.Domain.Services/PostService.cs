using AutoMapper;
using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Domain.Services
{
    public class PostService : IPostService
    {
        private IPostRepository postRepository;
        private ICategoryRepository categoryRepository;
        private IMapper mapper;

        public PostService(IPostRepository postRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }
      
        public void CreatePost(PostDomainModel postDomainModel, string userId)
        {
            var post = mapper.Map<Post>(postDomainModel);
            postRepository.CreatePost(post, userId);
            post.Created = DateTime.Now;
            post.Updated = DateTime.Now;
            postRepository.Save();
        }

        public void DeletePost(int postId)
        {
            postRepository.DeletePost(postId);
            postRepository.Save();
        }

        public IEnumerable<PostDomainModel> GetPosts()
        {
            var posts = postRepository.GetPostsOrderByRating();
            var postsDomainModel = mapper.Map<List<PostDomainModel>>(posts);
            return postsDomainModel;
        }

        public IEnumerable<PostDomainModel> GetPostsByUserId(string userId)
        {
            var post = postRepository.GetPostsByUserId(userId);
            var postDomainModel = mapper.Map<List<PostDomainModel>>(post);
            return postDomainModel;
        }

        public PostDomainModel FindPost(int postId)
        {
            var post =postRepository.FindPostByPostId(postId);
            var postDomainModel = mapper.Map<PostDomainModel>(post);
            return postDomainModel;
        }

        public void UpdatePost(PostDomainModel post)
        {
            var updatePost = mapper.Map<Post>(post);
            postRepository.UpdatePost(updatePost);
            updatePost.Updated = DateTime.Now;
            postRepository.Save();
        }
    }
}
