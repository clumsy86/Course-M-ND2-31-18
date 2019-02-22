using AutoMapper;
using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IProfilService profileService;
        private readonly ICommentService commentService;
        private readonly IPostService postService;
        private readonly ILikeService likeService;
        private IUserRepository userRepository;
        private IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, IProfilService profileService, 
            ICommentService commentService, IPostService postService, ILikeService likeService)
        {
            this.postService = postService;
            this.profileService = profileService;
            this.commentService = commentService;
            this.likeService = likeService;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public void DeleteUser(string userId)
        {
            likeService.DeleteLikes(userId);
            commentService.DeleteComments(userId);
            postService.DeletePosts(userId);
            profileService.DeleteProfile(userId);
            userRepository.DeleteUser(userId);
            userRepository.Save();
        }

        public string FindUsername(string userId)
        {
            return userRepository.FindUserName(userId);
        }

        public IEnumerable<UserDomainModel> GetUsers()
        {
            var users = userRepository.GetUsers();
            var usersDomainModel = mapper.Map<List<UserDomainModel>>(users);
            return usersDomainModel;
        }

        public UserDomainModel FindUserById(string userId)
        {
            var user = userRepository.FindUser(userId);
            var userDomainModel = mapper.Map<UserDomainModel>(user);
            return userDomainModel;
        }

        public void UpdateUser(UserDomainModel user)
        {
            var updateUser = mapper.Map<ApplicationUser>(user);
            userRepository.UpdateUser(updateUser);
            userRepository.Save();
        }
    }
}
