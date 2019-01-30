using System;

namespace ITNews.Web1.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool Published { get; set; }

        public DateTime Created { get; set; }

        public string ShortDiscription { get; set; }

        public int Rating { get; set; }

        public DateTime Updated { get; set; }

        public UserViewModel User { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}
