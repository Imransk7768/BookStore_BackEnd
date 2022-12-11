using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartBL icartBL;
        public CartController(ICartBL icartBL)
        {
            this.icartBL = icartBL;
        }

        [HttpPost]
        [Route("Register")]
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
    }
}
