using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class AdminModel
    {
        //[Key]
        //public string AdminId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
    }
    public class AdminLoginModel
    {
        //[Key]
        //public string AdminId { get; set; }
        //public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string Mobile { get; set; }
    }
}
