using ITNews.Domain.Contracts.Entities;


namespace ITNews.Domain.Services
{
    public interface IProfileService
    {
        void CreateProfile(ProfileDomainModel profileDomainModel, string userId);

        void EditProfile(ProfileDomainModel profileDomainModel, string userId);
    }
}
