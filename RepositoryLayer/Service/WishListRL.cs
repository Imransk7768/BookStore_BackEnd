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
    public class WishListRL : IWishListRL
    {
        private readonly IConfiguration iConfiguration;
        public WishListRL(IConfiguration iconfiguration)
        {
            this.iConfiguration = iconfiguration;
        }
        public WishListModel AddWishList(int bookId, long userId)
        {
            WishListModel wishListModel = new WishListModel();
<<<<<<< HEAD

=======
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))

                try
                {
                    SqlCommand cmd = new SqlCommand("spAddWishList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result != 0)
                    {
                        return wishListModel;
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
        public bool DeleteWishList(int WishlistId, long userId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                try
                {

                    SqlCommand cmd = new SqlCommand("spDeleteWishList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WishListId", WishlistId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
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
<<<<<<< HEAD
                catch (Exception ex)
                {
                    throw ex;
                }
        }
        public List<ViewWishListModel> GetWishlistDetailsByUserid(int userId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                try
                {
                    List<ViewWishListModel> list = new List<ViewWishListModel>();
                    SqlCommand command = new SqlCommand("spGetWishListById", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserId", userId);

                    con.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ViewWishListModel wish = new ViewWishListModel();
                            wish.BookId = Convert.ToInt32(dr["BookId"] == DBNull.Value ? default : dr["BookId"]);
                            wish.UserId = Convert.ToInt32(dr["UserId"] == DBNull.Value ? default : dr["UserId"]);
                            wish.WishlistId = Convert.ToInt32(dr["WishListId"] == DBNull.Value ? default : dr["WishListId"]);
                            wish.BookName = Convert.ToString(dr["BookName"] == DBNull.Value ? default : dr["BookName"]);
                            wish.AuthorName = Convert.ToString(dr["AuthorName"] == DBNull.Value ? default : dr["AuthorName"]);
                            wish.BookImage = Convert.ToString(dr["BookImage"] == DBNull.Value ? default : dr["BookImage"]);
                            wish.DiscountPrice = Convert.ToInt32(dr["DiscountPrice"] == DBNull.Value ? default : dr["DiscountPrice"]);
                            wish.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"] == DBNull.Value ? default : dr["OriginalPrice"]);
                            list.Add(wish);
                        }
                        return list;
                    }
                    else
                    {
                        con.Close();
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;

                }

=======
                catch (Exception)
                {
                    throw;
                }
        }
        public List<ViewWishListModel> GetWishlistDetailsByUserid(long userId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))

                try
                {
                    SqlCommand cmd = new SqlCommand("spGetWishListById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        List<ViewWishListModel> Wishlistmodels = new List<ViewWishListModel>();
                        while (dr.Read())
                        {
                            BookModel bookModel = new BookModel();
                            ViewWishListModel WishlistModel = new ViewWishListModel();
                            bookModel.BookId = Convert.ToInt32(dr["BookId"]);
                            bookModel.BookName = dr["BookName"].ToString();
                            bookModel.AuthorName = dr["AuthorName"].ToString();
                            bookModel.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]);
                            bookModel.DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]);
                            bookModel.BookImage = dr["BookImage"].ToString();
                            WishlistModel.UserId = Convert.ToInt32(dr["UserId"]);
                            WishlistModel.BookId = Convert.ToInt32(dr["BookId"]);
                            WishlistModel.WishlistId = Convert.ToInt32(dr["WishListId"]);
                            WishlistModel.BookModel = bookModel;
                            Wishlistmodels.Add(WishlistModel);
                        }
                        con.Close();
                        return Wishlistmodels;
                    }
                    else
                    {
                        return null;
                    }
            }
            catch (Exception)
            {
                throw;
            }
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
        }
    }
}
