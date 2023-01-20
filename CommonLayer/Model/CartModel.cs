using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class CartModel
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
<<<<<<< HEAD
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public string AuthorName { get; set; }
        public int DiscountPrice { get; set; }
        public int OriginalPrice { get; set; }
        public int BookQuantity { get; set; }
=======
        public int Quantity { get; set; }
        //public BookModel bookmodel { get; set; }
    }
    public class ViewCartModel
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public BookModel bookmodel { get; set; }
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
    }
}
