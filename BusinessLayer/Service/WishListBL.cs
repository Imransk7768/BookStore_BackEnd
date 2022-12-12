using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class WishListBL : IWishListBL
    {
        private readonly IWishListRL iwishListRL;
        public WishListBL(IWishListRL iwishListRL)
        {
            this.iwishListRL = iwishListRL;
        }
        public WishListModel AddWishList(WishListModel wishlistModel, int userId)
        {
            try
            {
                return iwishListRL.AddWishList(wishlistModel, userId);  
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteWishList(int WishlistId, int userId)
        {

            try
            {
                return iwishListRL.DeleteWishList(WishlistId, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ViewWishListModel> GetWishlistDetailsByUserid(int userId)
        {

            try
            {
                return iwishListRL.GetWishlistDetailsByUserid(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
