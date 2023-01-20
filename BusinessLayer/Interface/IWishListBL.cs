using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IWishListBL
    {
        public WishListModel AddWishList(int bookId, long userId);
        public bool DeleteWishList(int WishlistId, long userId);
<<<<<<< HEAD
        public List<ViewWishListModel> GetWishlistDetailsByUserid(int userId);
=======
        public List<ViewWishListModel> GetWishlistDetailsByUserid(long userId);
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
    }
}
