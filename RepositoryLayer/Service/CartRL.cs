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
    public class CartRL : ICartRL
    {
        private readonly IConfiguration iConfiguration;
        public CartRL(IConfiguration iconfiguration)
        {
            this.iConfiguration = iconfiguration;
        }
        public CartModel AddCart(CartModel cartModel)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                try
                {
                    using (con)
                    {
                        SqlCommand cmd = new SqlCommand("spAddCart", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserId", cartModel.UserId);
                        //cmd.Parameters.AddWithValue("@BookId", cartModel.BookId);
                        cmd.Parameters.AddWithValue("@Quantity", cartModel.Quantity);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        return cartModel;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }
    }
}
