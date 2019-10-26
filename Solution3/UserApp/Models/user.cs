using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserApp.Models
{
    public class user
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public Nullable<int> Phone { get; set; }
        public string Password { get; set; }
    }
}