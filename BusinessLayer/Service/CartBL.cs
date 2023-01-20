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
        public CartModel AddCart(int bookId, int userId)
        {
            try
            {
                return icartRL.AddCart(bookId, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        public List<CartModel> GetCartByUserid(int userId)

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
