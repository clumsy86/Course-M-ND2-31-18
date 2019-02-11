using System;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Repositories
{
    public interface IPostTagRepository: IDisposable
    {
        bool FindNotUsedTag(int tagId);

        void Save();

        List<int> GetPostTags(int postId);
    }
}
