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


<<<<<<< HEAD
        // public UserLogin Login(UserLogin userLogin);
        //public string UserLogin(LoginResponse userLog);

        public string ForgetPassword(string Email);
        public bool ResetPassword(string email, string newPassword, string confirmPassword);
        public List<GetUserModel> GetUserdetails(int userId);
=======
       // public UserLogin Login(UserLogin userLogin);
        public string ForgetPassword(string Email);
        public bool ResetPassword(string email, string newPassword, string confirmPassword);
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86

    }
}
