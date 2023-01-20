using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
<<<<<<< HEAD
using System.Linq;
=======
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
<<<<<<< HEAD
    //[Authorize]
=======
    [Authorize]
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86

    public class CartController : ControllerBase
    {
        private readonly ICartBL icartBL;
        public CartController(ICartBL icartBL)
        {
            this.icartBL = icartBL;
        }

<<<<<<< HEAD
        [Authorize]
        [HttpPost]
        [Route("AddCart")]
        //public IActionResult AddCart(int bookId,CartModel cartModel)
        //public IActionResult AddCart(AddCartModel cart)
        public IActionResult AddCart(int bookId)

        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = icartBL.AddCart(bookId, userId);
                //var result = icartBL.AddCart(bookId, userId, cartModel);
                //var result = icartBL.AddCart(cart);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Cart Created Succesful", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Cart Created Failed." });
=======
        [HttpPost]
        [Route("AddCart")]
        //for registration
        public IActionResult AddCart(CartModel cartModel)
        {
            try
            {
                var result = icartBL.AddCart(cartModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Cart Created Succesful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cart Created Failed." });
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdateCart")]
        public IActionResult UpdateCart(long cartid, CartModel cart)
        {
            try
            {
<<<<<<< HEAD
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
=======
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
                var result = this.icartBL.UpdateCart(cartid, cart);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Cart Details Updated Sucessfull", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "unable to Update" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("DeleteCart")]
        public IActionResult DeleteCart(long cartid)
        {
            try
            {
<<<<<<< HEAD
                //int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
=======
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
                var result = this.icartBL.DeleteCart(cartid);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Cart Details deleted Sucessfull", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "unable to delete" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

<<<<<<< HEAD
        //[Authorize]
        [HttpGet]
        [Route("GetAllCart")]
        public IActionResult GetCartDetails()
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
=======
        [HttpGet]
        [Route("GetAllCart")]
        public IActionResult GetCartDetails(int userId)
        {
            try
            {
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
                var result = this.icartBL.GetCartByUserid(userId);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Reteive Cart Details success", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Retrieve Cart Failed" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
