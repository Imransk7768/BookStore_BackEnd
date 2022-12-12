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
    public class WishListRL : IWishListRL
    {
        private readonly IConfiguration iConfiguration;
        public WishListRL(IConfiguration iconfiguration)
        {
            this.iConfiguration = iconfiguration;
        }
        public WishListModel AddWishList(WishListModel wishlistModel, int userId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))

                try
                {
                    SqlCommand cmd = new SqlCommand("spAddWishList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", wishlistModel.BookId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result != 0)
                    {
                        return wishlistModel;
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
        public bool DeleteWishList(int WishlistId, int userId)
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
                catch (Exception)
                {
                    throw;
                }
        }
        public List<ViewWishListModel> GetWishlistDetailsByUserid(int userId)
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
        }
    }
}
