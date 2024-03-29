﻿using CommonLayer.Model;
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
<<<<<<< HEAD


        //public CartModel AddCart(int bookId, int userId, CartModel cartModel)
        //{
        //    CartModel cartModel = new CartModel();
        //    using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("spAddCart", con);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@BookId", bookId);
        //            cmd.Parameters.AddWithValue("@UserId", userId);
        //            cmd.Parameters.AddWithValue("@BookQuantity", cartModel.BookQuantity);
        //            con.Open();
        //            var result = cmd.ExecuteNonQuery();
        //            con.Close();

        //            if (result > 0)
        //            {
        //                return cartModel;
        //            }
        //            else
        //            {
        //                return null;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //}

        public CartModel AddCart(int bookId, int userId)
        {
            CartModel cartModel = new CartModel();
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                try
                {
                    SqlCommand command = new SqlCommand("spAddCart", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@BookQuantity", cartModel.BookQuantity);

                    con.Open();
                    int result = command.ExecuteNonQuery();
                    con.Close();

                    if (result > 0)
                    {
                        return cartModel;
                    }
                    else
                    {
                        return null;
=======
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
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
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
<<<<<<< HEAD
                        cmd.Parameters.AddWithValue("@BookQuantity", cartModel.BookQuantity);
=======
                        cmd.Parameters.AddWithValue("@OrderQuantity", cartModel.Quantity);
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
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
<<<<<<< HEAD
        public List<CartModel> GetCartByUserid(int userId)
=======
        public List<ViewCartModel> GetCartByUserid(int userId)
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))

            try
            {
<<<<<<< HEAD
                    List<CartModel> cartmodels = new List<CartModel>();
                    using (con)
                    {
                        SqlCommand cmd = new SqlCommand("spGetCartByUserId", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                CartModel cartModel = new CartModel();
                                cartModel.BookId = Convert.ToInt32(dr["BookId"]);
                                cartModel.BookName = dr["BookName"].ToString();
                                cartModel.AuthorName = dr["AuthorName"].ToString();
                                cartModel.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]);
                                cartModel.DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]);
                                cartModel.BookImage = dr["BookImage"].ToString();
                                cartModel.UserId = Convert.ToInt32(dr["UserId"]);
                                cartModel.CartId = Convert.ToInt32(dr["CartId"]);
                                cartModel.BookQuantity = Convert.ToInt32(dr["BookQuantity"]);
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
=======
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
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
