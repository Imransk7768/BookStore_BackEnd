using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class BookModel
    {
        [Key]
<<<<<<< HEAD
        //public int BookId { get; set; }
        //public string BookName { get; set; }
        //public string AuthorName { get; set; }
        //public decimal Rating { get; set; }
        //public int TotalRating { get; set; }
        //public int DiscountPrice { get; set; }
        //public int OriginalPrice { get; set; }
        //public int BookCount { get; set; }
        //public string Description { get; set; }
        //public string BookImage { get; set; }
=======
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public decimal Rating { get; set; }
        public int TotalRating { get; set; }
        public int DiscountPrice { get; set; }
        public int OriginalPrice { get; set; }
<<<<<<< HEAD
        public string Description { get; set; }
        public string BookImage { get; set; }
        public int BookQuantity { get; set; }
=======
        public int BookCount { get; set; }
        public string Description { get; set; }
        public string BookImage { get; set; }
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
    }
}
