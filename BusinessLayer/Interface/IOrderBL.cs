using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IOrderBL
    {
        public string AddOrder(OrderModel orderModel, int userId);

        public List<GetOrderModel> GetOrderById(long userId);
        public bool DeleteOrder(int orderId);

    }
}
