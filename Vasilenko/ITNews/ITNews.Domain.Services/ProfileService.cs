﻿using AutoMapper;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;


namespace ITNews.Domain.Services
{
    public class ProfileService :IProfilService
    {
        private IProfileRepository profileRepository;
        private IMapper mapper;

        public ProfileService(IProfileRepository profileRepository, IMapper mapper)
        {
            this.profileRepository = profileRepository;
            this.mapper = mapper;
        }

        public void CreateProfile(ProfileDomainModel profileDomainModel, string userId)
        {
            var profile = mapper.Map <Data.Contracts.Entities.Profile >(profileDomainModel);
            profileRepository.CreateProfile(profile, userId);
            profileRepository.Save();
        }

        public void EditProfile(ProfileDomainModel profileDomainModel)
        {
            var profile = mapper.Map<Data.Contracts.Entities.Profile>(profileDomainModel);
            profileRepository.EditProfile(profile);
            profileRepository.Save();
        }

        public ProfileDomainModel FindProfile(string userId)
        {
            var profile = profileRepository.FindProfile(userId);
            var profileDomainModel = mapper.Map<ProfileDomainModel>(profile);
            return profileDomainModel;
        }

        public FullNameDomainModel FindFullName(string userId)
        {
            var profile = profileRepository.FindProfile(userId);
            FullNameDomainModel fullName = new FullNameDomainModel();
            fullName.FirstName = profile.FirstName;
            fullName.LastName = profile.LastName;
            return fullName;
        }

        public void SaveChangesFirstName(string userId, string firstname)
        {
            var profile = profileRepository.FindProfile(userId);
            profile.FirstName = firstname;
            profileRepository.Save();
        }

        public void SaveChangesLastName(string userId, string lastname)
        {
            var profile = profileRepository.FindProfile(userId);
            profile.LastName = lastname;
            profileRepository.Save();
        }

        public void SaveChangesCity(string userId, string city)
        {
            var profile = profileRepository.FindProfile(userId);
            profile.City = city;
            profileRepository.Save();
        }
    }
}
