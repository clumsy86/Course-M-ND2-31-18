namespace ITNews.Domain.Contracts.Entities
{
    public class LikeDomainModel
    {
        public int Id { get; set; }
       
        public CommentDomainModel Comment { get; set; }

        public UserDomainModel User { get; set; }
    }
}
