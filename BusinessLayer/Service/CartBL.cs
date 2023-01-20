using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CartBL :ICartBL
    {
        private readonly ICartRL icartRL;

        public CartBL(ICartRL icartRL)
        {
            this.icartRL = icartRL;
        }
<<<<<<< HEAD
        public CartModel AddCart(int bookId, int userId)
        {
            try
            {
                return icartRL.AddCart(bookId, userId);
=======
        public CartModel AddCart(CartModel cartModel)
        {
            try
            {
                return icartRL.AddCart(cartModel);
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
<<<<<<< HEAD
        //public CartModel AddCart(int bookId, int userId, CartModel cartModel)
        //{
        //    try
        //    {
        //        return icartRL.AddCart(bookId, userId, cartModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

=======
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
        public CartModel UpdateCart(long cartid, CartModel cartModel)
        {
            try
            {
                return icartRL.UpdateCart(cartid, cartModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteCart(long cartId)
        {
            try
            {
                return icartRL.DeleteCart(cartId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
<<<<<<< HEAD
        public List<CartModel> GetCartByUserid(int userId)
=======
        public List<ViewCartModel> GetCartByUserid(int userId)
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86

        {
            try
            {
                return icartRL.GetCartByUserid(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
