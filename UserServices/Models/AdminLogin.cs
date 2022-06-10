using System;
using System.Collections.Generic;

namespace UserServices.Models
{
    public partial class AdminLogin
    {
        public int Adminid { get; set; }
        public string AdminUn { get; set; }
        public string AdminPassword { get; set; }
        public string AdminName { get; set; }
    }
}
