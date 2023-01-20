using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBL iadminBL;

        public AdminController(IAdminBL iadminBL)
        {
            this.iadminBL = iadminBL;
        }

        [HttpPost]
        [Route("AddAdmin")]
        //for registration
        public IActionResult AddAdmin(AdminModel adminModel)
        {
            try
            {
                var result = iadminBL.AddAdmin(adminModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Admin Registrastion is Success", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Admin Registration is Failed." });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("AdminLogin")]
        public IActionResult AdminLogin(AdminLoginModel adminLogin)
        {
            try
            {
                var result = iadminBL.AdminLogin(adminLogin);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Admin Login Success", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Admin Login Failed" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
