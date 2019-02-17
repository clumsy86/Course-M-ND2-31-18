using ITNews.Domain.Contracts.Entities;

namespace ITNews.Domain.Contracts
{
    public interface IProfilService
    {
        void CreateProfile(ProfileDomainModel profileDomainModel, string userId);

        void EditProfile(ProfileDomainModel profileDomainModel, string userId);

        ProfileDomainModel FindProfile(string userId);
    }
}
