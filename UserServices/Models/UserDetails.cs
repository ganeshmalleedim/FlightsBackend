using System;
using System.Collections.Generic;

namespace UserServices.Models
{
    public partial class UserDetails
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int? Phone { get; set; }
    }
}
