namespace ITNews.Domain.Contracts.Entities
{
    public class PostTagDomainModel
    {
        public PostDomainModel Post { get; set; }

        public TagDomainModel Tag { get; set; }
    }
}
