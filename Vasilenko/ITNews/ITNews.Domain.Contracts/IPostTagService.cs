using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Contracts
{
    public interface IPostTagService
    {
        IEnumerable<PostTagDomainModel> GetPostsTags();
    }
}
