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
<<<<<<< HEAD
        public List<ViewWishListModel> GetWishlistDetailsByUserid(int userId)
=======
        public List<ViewWishListModel> GetWishlistDetailsByUserid(long userId)
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
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
