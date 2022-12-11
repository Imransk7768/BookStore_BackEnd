using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CartBL
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
