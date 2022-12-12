using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        public CartModel AddCart(CartModel cartModel);
        public CartModel UpdateCart(long cartid, CartModel cartModel);
        public bool DeleteCart(long cartId);
        public List<ViewCartModel> GetCartByUserid(int userId);


    }
}
