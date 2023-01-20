using CommonLayer.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public UserReg Registration(UserReg userReg);
        public string Login(UserLogin userLogin);

        //public UserLogin Login(UserLogin userLogin);
<<<<<<< HEAD
        //public string UserLogin(LoginResponse userLog);

        public string ForgetPassword(string Email);
        public bool ResetPassword(string email, string newPassword, string confirmPassword);
        public List<GetUserModel> GetUserdetails(int userId);
=======
        public string ForgetPassword(string Email);
        public bool ResetPassword(string email, string newPassword, string confirmPassword);
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86

    }
}
