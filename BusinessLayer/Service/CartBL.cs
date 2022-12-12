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
        public CartModel AddCart(CartModel cartModel)
        {
            try
            {
                return icartRL.AddCart(cartModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        public List<ViewCartModel> GetCartByUserid(int userId)

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
