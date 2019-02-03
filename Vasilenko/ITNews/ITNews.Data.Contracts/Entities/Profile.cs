﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITNews.Data.Contracts.Entities
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Avatar { get; set; }
  
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
