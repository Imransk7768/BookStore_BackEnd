using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
<<<<<<< HEAD
=======
    [Authorize]
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86

    public class FeedBackController : ControllerBase
    {
        private readonly IFeedBackBL iFeedBackBL;

        public FeedBackController(IFeedBackBL iFeedBackBL)
        {
            this.iFeedBackBL = iFeedBackBL;
        }
<<<<<<< HEAD

        [Authorize]
=======
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
        [HttpPost]
        [Route("AddFeedBack")]
        public IActionResult AddFeedback(FeedBackModel feedback)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = iFeedBackBL.AddFeedback(feedback, userId);
                if (result != null)
                {
<<<<<<< HEAD
                    return this.Ok(new { Status = true, message = "FeedBack Added Success", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Failed to add FeedBack" });
=======
                    return this.Ok(new { Status = true, Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Failed to add" });
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetFeedBack")]
        public IActionResult GetFeedback(int bookId)
        {
            try
            {
                var result = iFeedBackBL.GetFeedback(bookId);
                if (result != null)
                {
<<<<<<< HEAD
                    return this.Ok(new { Status = true, message = " Retrieve FeedBack Success", Data = result });
=======
                    return this.Ok(new { Status = true, Data = result });
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Failed to get" });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
