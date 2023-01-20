using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class OrderBL : IOrderBL
    {
        private readonly IOrderRL iorderRL;
        public OrderBL(IOrderRL iorderRL)
        {
            this.iorderRL = iorderRL;
        }
<<<<<<< HEAD
        public string AddOrder(OrderModel orderModel, int userId)

=======
        public OrderModel AddOrder(OrderModel orderModel, long userId)
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
        {
            try
            {
                return this.iorderRL.AddOrder(orderModel, userId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<GetOrderModel> GetOrderById(long userId)
        {
            try
            {
                return this.iorderRL.GetOrderById(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
<<<<<<< HEAD
        public bool DeleteOrder(int orderId)
        {
            try
            {
                return this.iorderRL.DeleteOrder(orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

=======
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
    }
}
