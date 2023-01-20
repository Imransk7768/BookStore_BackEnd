using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class UserLogin
    {
        //public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserIdLogin
    {
        public int UserId { get; set; }
    }
    public class GetUserModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public long Mobile { get; set; }
    }
}
