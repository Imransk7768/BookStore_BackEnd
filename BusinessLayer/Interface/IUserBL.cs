using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserReg Registration(UserReg userReg);
        public string Login(UserLogin userLogin);


        // public UserLogin Login(UserLogin userLogin);
        //public string UserLogin(LoginResponse userLog);

        public string ForgetPassword(string Email);
        public bool ResetPassword(string email, string newPassword, string confirmPassword);
        public List<GetUserModel> GetUserdetails(int userId);

    }
}
