using System;

namespace ITNews.Web1.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public PostViewModel Post { get; set; }

        public UserViewModel User { get; set; }
    }
}
