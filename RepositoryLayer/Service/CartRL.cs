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
                        cmd.Parameters.AddWithValue("@BookId", cartModel.BookId);
                        cmd.Parameters.AddWithValue("@OrderQuantity", cartModel.Quantity);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        int result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result != 0)
                        {
                            return cartModel;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }
        public CartModel UpdateCart(long cartid, CartModel cartModel)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                try
                {
                    using (con)
                    {
                        SqlCommand cmd = new SqlCommand("spUpdateCart", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CartId", cartid);
                        cmd.Parameters.AddWithValue("@UserId", cartModel.UserId);
                        cmd.Parameters.AddWithValue("@BookId", cartModel.BookId);
                        cmd.Parameters.AddWithValue("@OrderQuantity", cartModel.Quantity);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result != 0)
                        {
                            return cartModel;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }
        public bool DeleteCart(long cartId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                try
            {
                    using (con)
                    {
                        SqlCommand cmd = new SqlCommand("spDeleteCart", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CartId", cartId);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result >= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ViewCartModel> GetCartByUserid(int userId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))

            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("spGetCartByUserId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        List<ViewCartModel> cartmodels = new List<ViewCartModel>();
                        while (dr.Read())
                        {
                            BookModel bookModel = new BookModel();
                            ViewCartModel cartModel = new ViewCartModel();
                            bookModel.BookId = Convert.ToInt32(dr["BookId"]);
                            bookModel.BookName = dr["BookName"].ToString();
                            bookModel.AuthorName = dr["AuthorName"].ToString();
                            bookModel.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]);
                            bookModel.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]);
                            bookModel.DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]);
                            bookModel.BookImage = dr["BookImage"].ToString();
                            cartModel.UserId = Convert.ToInt32(dr["UserId"]);
                            cartModel.BookId = Convert.ToInt32(dr["BookId"]);
                            cartModel.CartId = Convert.ToInt32(dr["CartId"]);
                            cartModel.Quantity = Convert.ToInt32(dr["OrderQuantity"]);
                            cartModel.bookmodel = bookModel;
                            cartmodels.Add(cartModel);
                        }
                        con.Close();
                        return cartmodels;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
