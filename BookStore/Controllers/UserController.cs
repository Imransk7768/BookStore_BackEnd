using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;


namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        private readonly IUserBL iuserBL;

        public UserController(IUserBL iuserBL)
        {
            this.iuserBL = iuserBL;
        }

        [HttpPost("Register")]
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //for login
        [HttpPost("Login")]
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


    }
}
