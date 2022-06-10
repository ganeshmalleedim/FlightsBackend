using System;
using System.Collections.Generic;

namespace AdminServices.Models
{
    public partial class AdminLogin
    {
        public int Adminid { get; set; }
        public string AdminUn { get; set; }
        public string AdminPassword { get; set; }
        public string AdminName { get; set; }
    }
}
