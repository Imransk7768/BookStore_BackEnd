using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CartController : ControllerBase
    {
        private readonly ICartBL icartBL;
        public CartController(ICartBL icartBL)
        {
            this.icartBL = icartBL;
        }

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

        [HttpGet]
        [Route("GetAllCart")]
        public IActionResult GetCartDetails(int userId)
        {
            try
            {
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
