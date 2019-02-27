using System.Collections.Generic;
using System.ComponentModel;

namespace ITNews.Web1.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Avatar { get; set; }

        public string UserId { get; set; }

        public RoleViewModel Role { get; set; }

        public UserViewModel User { get; set; }

        public List<RoleViewModel> Roles { get; set; }
    }
}
