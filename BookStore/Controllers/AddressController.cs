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
    public class AddressController : ControllerBase
    {
        private readonly IAddressBL iaddressBL;

        public AddressController(IAddressBL iaddressBL)
        {
            this.iaddressBL = iaddressBL;
        }

        [Authorize]
        [HttpPost]
        [Route("AddAddress")]
        public IActionResult AddAddress(AddressModel addressModel)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = this.iaddressBL.AddAddress(addressModel, userId);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Address Details Sucessfull", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Data Added to Address" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        [Route("UpdateAddress")]

        public IActionResult UpdateAddress(AddressModel addressModel, int addressId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = this.iaddressBL.UpdateAddress(addressModel, addressId, userId);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Address Updated Sucess", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Update Adress Failed" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("DeleteAddress")]
        public IActionResult DeleteAddress(int addressId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = this.iaddressBL.DeleteAddress(addressId,userId);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Address Deleted Sucess", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Adress Delete Failed" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetAllAddress")]
        public IActionResult GetUserAddress()
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = this.iaddressBL.GetAllAddresses(userId);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Address Data Retrieved Sucess", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Retrieve Address data Failed" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        
    }
}
