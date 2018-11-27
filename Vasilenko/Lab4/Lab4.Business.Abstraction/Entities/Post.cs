using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Business.Abstraction.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public User User { get; set; }

    }
}
