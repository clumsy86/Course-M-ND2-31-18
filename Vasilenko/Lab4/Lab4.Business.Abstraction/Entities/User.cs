using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Business.Abstraction.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ConfirmedEmail { get; set; }

    }
}
