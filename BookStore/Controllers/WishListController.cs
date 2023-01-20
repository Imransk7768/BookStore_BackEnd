using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookStore.Controllers
{
<<<<<<< HEAD
    //[Authorize(Roles = Role.Users)]
    [Route("api/[controller]")]
    [ApiController]
=======
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
    public class WishListController : ControllerBase
    {
        private readonly IWishListBL iwishListBL;

        public WishListController(IWishListBL iwishListBL)
        {
            this.iwishListBL = iwishListBL;
        }

<<<<<<< HEAD
        [Authorize]
=======
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
        [HttpPost]
        [Route("AddWishList")]
        public IActionResult AddWishList(int bookId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = this.iwishListBL.AddWishList(bookId, userId);
                if (result != null)
                {

                    return this.Ok(new { Success = true, message = "Book Added to Wishlist", Response = result });

                }
                else
                {
                    return this.BadRequest(new { Success = true, message = "Book not added to wishlist", Response = result });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("DeleteWishList")]
        public IActionResult DeleteWishList(int wishlistid)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = this.iwishListBL.DeleteWishList(wishlistid, userId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Book Removed from WishList Success", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Failed to Remove" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
<<<<<<< HEAD
        [Route("GetWishList")]
=======
        [Route("RetrieveWishList")]
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86

        public IActionResult GetWishlist()
        {
            try
            {
<<<<<<< HEAD
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
=======
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86

                var result = this.iwishListBL.GetWishlistDetailsByUserid(userId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Wishlist Retrieve Success", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Retrieve WishList Failed" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
