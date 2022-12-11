using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IAdminBL
    {
        public AdminModel AddAdmin(AdminModel adminModel);
        public string AdminLogin(AdminModel adminModel);

    }
}
