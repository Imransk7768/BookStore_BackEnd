using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRL
    {
<<<<<<< HEAD
        public CartModel AddCart(int bookId, int userId);
        //public CartModel AddCart(int bookId, int userId, CartModel cartModel);
        //public AddCartModel AddCart(AddCartModel cart);

        public CartModel UpdateCart(long cartid, CartModel cartModel);
        public bool DeleteCart(long cartId);
        public List<CartModel> GetCartByUserid(int userId);
=======
        public CartModel AddCart(CartModel cartModel);
        public CartModel UpdateCart(long cartid, CartModel cartModel);
        public bool DeleteCart(long cartId);
        public List<ViewCartModel> GetCartByUserid(int userId);
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86


    }
}
