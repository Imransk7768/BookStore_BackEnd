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
    [Authorize]

    public class OrderController : ControllerBase
    {
        private readonly IOrderBL iorderBL;
        public OrderController(IOrderBL iorderBL)
        {
            this.iorderBL = iorderBL;

        }
        [HttpPost]
        [Route("AddOrder")]
        public IActionResult AddOrder(OrderModel orderModel)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = this.iorderBL.AddOrder(orderModel, userId);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Order Added Sucessfull", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Order Failed" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetOrders")]
        public IActionResult GetOrders()
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = this.iorderBL.GetOrderById(userId);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Get Order Data Success ", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Get Order Data Failed" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("DeleteOrder")]
        public IActionResult DeleteOrder(int orderId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = this.iorderBL.DeleteOrder(orderId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Order Deleted" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Failed to Delete Order" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
