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
        private IUserRepository userRepository;
        private IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public void DeleteUser(string userId)
        {
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

        public void UpdateUser(UserDomainModel user)
        {
            var updateUser = mapper.Map<ApplicationUser>(user);
            userRepository.UpdateUser(updateUser);
            userRepository.Save();
        }
    }
}
