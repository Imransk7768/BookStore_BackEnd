using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminRL iadminRL;

        public AdminBL(IAdminRL iadminRL)
        {
            this.iadminRL = iadminRL;
        }
        public AdminModel AddAdmin(AdminModel adminModel)
        {
            try
            {
                return this.iadminRL.AddAdmin(adminModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AdminLogin(AdminModel adminModel)
        {
            try
            {
                return this.iadminRL.AdminLogin(adminModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
