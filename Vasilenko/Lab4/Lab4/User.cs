using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labs4.DataAccess.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool ConfirmedEmail { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public User()
        {
            Posts = new List<Post>();
        }

    }
}
