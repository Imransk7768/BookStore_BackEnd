using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int AddressId { get; set; }
        public int BookQuantity { get; set; }
        public DateTime OrderDate { get; set; }
        //public BookModel bookModel { get; set; }
    }
    public class GetOrderModel
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int AddressId { get; set; }
        public int BookQuantity { get; set; }
        public DateTime OrderDate { get; set; }
        public BookModel bookModel { get; set; }
    }
}
