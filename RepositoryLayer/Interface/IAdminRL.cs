﻿using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAdminRL
    {
        public AdminModel AddAdmin(AdminModel adminModel);
        public string AdminLogin(AdminLoginModel adminLogin);

    }
}
