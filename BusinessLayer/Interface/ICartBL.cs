using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        public CartModel AddCart(int bookId, int userId);
        //public CartModel AddCart(int bookId, int userId, CartModel cartModel);
        //public AddCartModel AddCart(AddCartModel cart);

        public CartModel UpdateCart(long cartid, CartModel cartModel);
        public bool DeleteCart(long cartId);
        public List<CartModel> GetCartByUserid(int userId);


    }
}
