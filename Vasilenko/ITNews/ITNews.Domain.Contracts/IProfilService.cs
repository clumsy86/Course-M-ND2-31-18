using ITNews.Domain.Contracts.Entities;

namespace ITNews.Domain.Contracts
{
    public interface IProfilService
    {
        void CreateProfile(ProfileDomainModel profileDomainModel, string userId);

        void EditProfile(ProfileDomainModel profileDomainModel);

        ProfileDomainModel FindProfile(string userId);

        void SaveChangesFirstName(string userId, string firstname);

        void SaveChangesLastName(string userId, string lastname);

        void SaveChangesCity(string userId, string city);

        FullNameDomainModel FindFullName(string userId);
    }
}
