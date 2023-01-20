using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IOrderBL
    {
<<<<<<< HEAD
        public string AddOrder(OrderModel orderModel, int userId);

        public List<GetOrderModel> GetOrderById(long userId);
        public bool DeleteOrder(int orderId);

=======
        public OrderModel AddOrder(OrderModel orderModel, long userId);
        public List<GetOrderModel> GetOrderById(long userId);
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
    }
}
