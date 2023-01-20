using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class WishListModel
    {
        public int BookId { get; set; }

       
    }
    public class ViewWishListModel
    {
        public int WishlistId { get; set; }
<<<<<<< HEAD
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int DiscountPrice { get; set; }
        public int OriginalPrice { get; set; }
        public string BookImage { get; set; }
=======
        public int BookId { get; set; }
        public int UserId { get; set; }
        
        public BookModel BookModel { get; set; }
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
    }
}
  