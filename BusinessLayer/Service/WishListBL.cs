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
        public WishListModel AddWishList(int bookId, long userId)
        {
            try
            {
                return iwishListRL.AddWishList(bookId, userId);  
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteWishList(int WishlistId, long userId)
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
        public List<ViewWishListModel> GetWishlistDetailsByUserid(long userId)
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
