using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Contracts
{
    public interface ITagService
    {
        IEnumerable<TagDomainModel> GetTags();

        void DeleteTags (int postId);

        void CreateTags(IEnumerable<TagDomainModel> tags, int postId);
    }
}
