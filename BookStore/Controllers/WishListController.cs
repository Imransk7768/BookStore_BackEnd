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
    public class WishListController : ControllerBase
    {
        private readonly IWishListBL iwishListBL;

        public WishListController(IWishListBL iwishListBL)
        {
            this.iwishListBL = iwishListBL;
        }

        [HttpPost]
        [Route("AddWishList")]
        public IActionResult AddWishList(WishListModel wishlistModel, int userId)
        {
            try
            {
                var result = this.iwishListBL.AddWishList(wishlistModel, userId);
                if (result.Equals("Book Wishlisted successfully"))
                {

                    return this.Ok(new { Success = true, message = "Book removed from wishlist", Response = result });

                }
                else
                {
                    return this.BadRequest(new { Success = true, message = "Book removed from wishlist", Response = result });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("DeleteWishList")]
        public IActionResult DeleteWishList(int wishlistid, int userId)
        {
            try
            {
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
        [Route("RetrieveWishList")]

        public IActionResult GetWishlist(int userid)
        {
            try
            {
                var result = this.iwishListBL.GetWishlistDetailsByUserid(userid);
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
