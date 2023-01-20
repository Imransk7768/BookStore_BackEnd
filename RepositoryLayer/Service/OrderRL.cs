using CommonLayer.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RepositoryLayer.Service
{
    public class OrderRL : IOrderRL
    {
        private readonly IConfiguration iConfiguration;
        public OrderRL(IConfiguration iconfiguration)
        {
            this.iConfiguration = iconfiguration;
        }
<<<<<<< HEAD
        public string AddOrder(OrderModel orderModel, int userId)
=======
        public OrderModel AddOrder(OrderModel orderModel, long userId)
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                try
                {
<<<<<<< HEAD
                SqlCommand cmd = new SqlCommand("spAddOrders", con);
=======
                SqlCommand cmd = new SqlCommand("AddOrders", con);
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookQuantity", orderModel.BookQuantity);
                cmd.Parameters.AddWithValue("@BookId", orderModel.BookId);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@AddressId", orderModel.AddressId);

                con.Open();
                var result = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

<<<<<<< HEAD
                if (result != 0)
                {
                    return "Order Placed";
=======
                if (result != 2 && result != 3)
                {
                    return orderModel;
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GetOrderModel> GetOrderById(long userId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
            {

                List<GetOrderModel> ordersList = new List<GetOrderModel>();
                SqlCommand com = new SqlCommand("GetOrderById", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UserId", userId);

                con.Open();
                com.ExecuteNonQuery();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        GetOrderModel orders = new GetOrderModel();
                        BookModel booksModel = new BookModel();
                        orders.OrderId = Convert.ToInt32(dr["OrderId"]);
                        booksModel.BookName = dr["BookName"].ToString();
                        booksModel.AuthorName = dr["AuthorName"].ToString();
                        booksModel.BookId = Convert.ToInt32(dr["BookId"]);
                        booksModel.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]);
                        booksModel.DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]);
                        booksModel.BookImage = dr["BookImage"].ToString();
                        orders.bookModel = booksModel;
                        ordersList.Add(orders);
                    }
                    dr.Close();
                    return ordersList;
                }
                return null;
            }
        }
<<<<<<< HEAD
        public bool DeleteOrder(int orderId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                try
                {
                SqlCommand cmd = new SqlCommand("spDeleteOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OrderId", orderId);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();

                if (result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
