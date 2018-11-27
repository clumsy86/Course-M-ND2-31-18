using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labs4.DataAccess.Entity
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(240)]
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}
