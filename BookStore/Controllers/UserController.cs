using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserBL iuserBL;

        public UserController(IUserBL iuserBL)
        {
            this.iuserBL = iuserBL;
        }

        [HttpPost]
        [Route("Register")]
        //for registration
        public IActionResult RegisterUser(UserReg userReg)
        {
            try
            {
                var result = iuserBL.Registration(userReg);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Registrastion is succesful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Registration is not successful." });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //for login
        [HttpPost]
        [Route("Login")]

        //public IActionResult LoginUser(LoginResponse userLog)
        //{
        //    try
        //    {
        //        var result = iuserBL.UserLogin(userLog);
        public IActionResult LoginUser(UserLogin userLogin)
        {
            try
            {
                var result = iuserBL.Login(userLogin);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Login succesful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Login Unsuccessful." });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("ForgetPassword")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                string token = iuserBL.ForgetPassword(email);
                if (token != null)
                {
                    return Ok(new { success = true, Message = "Please check your Email.Token sent succesfully.", data=token });
                }
                else
                {
                    return this.BadRequest(new { Success = false, Message = "Email not registered" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(string newPassword, string confirmPassword)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var data = iuserBL.ResetPassword(email, newPassword, confirmPassword);
                if (data != null)
                {
                    return Ok(new { success = true, message = "Reset Successful", data=data});
                }
                else
                {
                    return BadRequest(new { success = false, message = "Reset denied." });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize(Roles = Role.Users)]
        [HttpGet]
        [Route("GetUserDetails")]
        public IActionResult GetUerDetails()
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = iuserBL.GetUserdetails(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "User data", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Failed to fetch" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
