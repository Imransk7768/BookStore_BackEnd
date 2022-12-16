using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL iuserRL;
        public UserBL(IUserRL iuserRL)
        {
            this.iuserRL = iuserRL;
        }
        public UserReg Registration(UserReg userReg)
        {
            try
            {
                return iuserRL.Registration(userReg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Login(UserLogin userLogin)

        {
            try
            {
                return iuserRL.Login(userLogin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ForgetPassword(string Email)
        {
            try
            {
                return iuserRL.ForgetPassword(Email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ResetPassword(string email,string newPassword,string confirmPassword)
        {
            try
            {
                return iuserRL.ResetPassword(email,newPassword,confirmPassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
