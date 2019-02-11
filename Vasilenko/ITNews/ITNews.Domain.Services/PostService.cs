using AutoMapper;
using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITNews.Domain.Services
{
    public class PostService : IPostService
    {
        private IPostRepository postRepository;
        private ICategoryRepository categoryRepository;
        private ITagRepository tagRepository;
        private IPostTagRepository postTagRepository;
        private IMapper mapper;

        public PostService(IPostRepository postRepository, IMapper mapper, ICategoryRepository categoryRepository, 
            ITagRepository tagRepository, IPostTagRepository postTagRepository)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
            this.tagRepository = tagRepository;
            this.postTagRepository = postTagRepository;
        }
      
        public int CreatePost(PostDomainModel postDomainModel, string userId)
        {
            var post = mapper.Map<Post>(postDomainModel);
            postRepository.CreatePost(post, userId);
            post.Created = DateTime.Now;
            post.Updated = DateTime.Now;
            postRepository.Save();
            var postId = postRepository.GetPostId(post);
            return postId;
        }

        public void DeletePost(int postId)
        {
            var tags = postTagRepository.GetPostTags(postId);

            postRepository.DeletePost(postId);

            postRepository.Save();
          
            foreach (var item in tags)

                if (postTagRepository.FindNotUsedTag(item))
                {
                    tagRepository.DeleteTag(item);

                    tagRepository.Save();
                }
            
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
            var post = postRepository.FindPostByPostId(postId);
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
