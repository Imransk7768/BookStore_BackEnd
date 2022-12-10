using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserReg Registration(UserReg userReg);
        public string Login(string email, string password);

       // public UserLogin Login(UserLogin userLogin);
        public string ForgetPassword(string Email);
        public bool ResetPassword(string email, string newPassword, string confirmPassword);

    }
}
