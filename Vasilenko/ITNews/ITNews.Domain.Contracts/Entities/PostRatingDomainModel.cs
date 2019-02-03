namespace ITNews.Domain.Contracts.Entities
{
    public class PostRatingDomainModel
    {
        public int Id { get; set; }

        public int Mark { get; set; }
        
        public PostDomainModel Post { get; set; }

        public UserDomainModel User { get; set; }
    }
}
