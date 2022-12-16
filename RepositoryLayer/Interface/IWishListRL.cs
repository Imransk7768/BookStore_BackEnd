using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IWishListRL
    {
        public WishListModel AddWishList(int bookId, long userId);

        public bool DeleteWishList(int WishlistId, long userId);
        public List<ViewWishListModel> GetWishlistDetailsByUserid(long userId);

    }
}
