using AutoMapper;
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

        public void EditProfile(ProfileDomainModel profileDomainModel, string userId)
        {
            var profile = mapper.Map<Data.Contracts.Entities.Profile>(profileDomainModel);
            profileRepository.EditProfile(profile, userId);
            profileRepository.Save();
        }

        public ProfileDomainModel FindProfile(string userId)
        {
            var profile = profileRepository.FindProfile(userId);
            var profileDomainModel = mapper.Map<ProfileDomainModel>(profile);
            return profileDomainModel;
        }
    }
}
