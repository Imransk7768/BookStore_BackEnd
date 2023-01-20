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
    public class BookRL : IBookRL
    {
        private SqlConnection con;
        private readonly IConfiguration iConfiguration;
        public BookRL(IConfiguration _configuration)
        {
            this.iConfiguration = _configuration;
        }
        public BookModel AddBook(BookModel bookModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))

                {
                    SqlCommand cmd = new SqlCommand("spAddBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName", bookModel.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);
                    cmd.Parameters.AddWithValue("@TotalRating", bookModel.TotalRating);
                    cmd.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@Description", bookModel.Description);
                    cmd.Parameters.AddWithValue("@BookImage", bookModel.BookImage);
<<<<<<< HEAD
                    cmd.Parameters.AddWithValue("@BookCount", bookModel.BookQuantity);
=======
                    cmd.Parameters.AddWithValue("@BookCount", bookModel.BookCount);
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return bookModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public BookModel UpdateBook(BookModel bookModel, long bookId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    cmd.Parameters.AddWithValue("@BookName", bookModel.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);
                    cmd.Parameters.AddWithValue("@TotalRating", bookModel.TotalRating);
                    cmd.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@Description", bookModel.Description);
                    cmd.Parameters.AddWithValue("@BookImage", bookModel.BookImage);
<<<<<<< HEAD
                    cmd.Parameters.AddWithValue("@BookCount", bookModel.BookQuantity);
=======
                    cmd.Parameters.AddWithValue("@BookCount", bookModel.BookCount);
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return bookModel;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteBook(long bookId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))

             try
             {
                 SqlCommand cmd = new SqlCommand("spDeleteBook", con);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@BookId", bookId);
             
                 con.Open();
                 int result = cmd.ExecuteNonQuery();
                 con.Close();
                 if (result >= 1)
                 {
                     return true;
                 }
                 return false;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
        }
<<<<<<< HEAD
        

=======
        public List<BookModel> GetAllBooks()
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
             try
             {
                 List<BookModel> addBook = new List<BookModel>();

                 SqlCommand com = new SqlCommand("spGetAllBooks", con);
                 com.CommandType = CommandType.StoredProcedure;
                 SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                 DataTable dt = new DataTable();
                 con.Open();
                 dataAdapter.Fill(dt);
                 foreach (DataRow dr in dt.Rows)
                 {

                     addBook.Add(
                       new BookModel
                       {
                           BookId = Convert.ToInt32(dr["BookId"]),
                           BookName = dr["BookName"].ToString(),
                           AuthorName = dr["AuthorName"].ToString(),
                           Rating = Convert.ToInt32(dr["Rating"]),
                           TotalRating = Convert.ToInt32(dr["TotalRating"]),
                           DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]),
                           OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]),
                           Description = dr["Description"].ToString(),
                           BookImage = dr["BookImage"].ToString()
                       });
                 }
                 return addBook;
             }
             catch (Exception)
             {

                 throw;
             }

        }
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
        public object GetBookById(long bookId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                try
                {
                    SqlCommand cmd = new SqlCommand("spGetBookByBookId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    con.Open();
                    BookModel bookModel = new BookModel();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            bookModel.BookId = Convert.ToInt32(dr["BookId"]);
                            bookModel.BookName = dr["BookName"].ToString();
                            bookModel.AuthorName = dr["AuthorName"].ToString();
                            bookModel.Rating = Convert.ToInt32(dr["Rating"]);
                            bookModel.TotalRating = Convert.ToInt32(dr["TotalRating"]);
                            bookModel.DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]);
                            bookModel.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]);
                            bookModel.Description = dr["Description"].ToString();
                            bookModel.BookImage = dr["BookImage"].ToString();
<<<<<<< HEAD
                            bookModel.BookImage = "../../../assets/" + bookModel.BookImage;
                            bookModel.BookQuantity = Convert.ToInt32(dr["BookCount"]);

=======
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
                        }
                        return bookModel;
                    }
                    return null;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
        }
<<<<<<< HEAD
        public List<BookModel> GetAllBooks()
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))

                try
                {

                List<BookModel> bookList = new List<BookModel>();
                {


                    SqlCommand cmd = new SqlCommand("spGetAllBooks", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            BookModel bookModel = new BookModel();

                            bookModel.BookId = Convert.ToInt32(rd["BookId"] == DBNull.Value ? default : rd["BookId"]);
                            bookModel.BookName = Convert.ToString(rd["BookName"] == DBNull.Value ? default : rd["BookName"]);
                            bookModel.AuthorName = Convert.ToString(rd["AuthorName"] == DBNull.Value ? default : rd["AuthorName"]);
                            bookModel.Rating = Convert.ToDecimal(rd["Rating"] == DBNull.Value ? default : rd["Rating"]);
                            bookModel.TotalRating = Convert.ToInt32(rd["TotalRating"] == DBNull.Value ? default : rd["TotalRating"]);
                            bookModel.DiscountPrice = Convert.ToInt32(rd["DiscountPrice"] == DBNull.Value ? default : rd["DiscountPrice"]);
                            bookModel.OriginalPrice = Convert.ToInt32(rd["OriginalPrice"] == DBNull.Value ? default : rd["OriginalPrice"]);
                            bookModel.Description = Convert.ToString(rd["Description"] == DBNull.Value ? default : rd["Description"]);
                            bookModel.BookImage = Convert.ToString(rd["BookImage"] == DBNull.Value ? default : rd["BookImage"]);
                            //if(bookModel.BookId==11)
                            //this string added for taking image from assets folder
                            bookModel.BookImage = "../../../assets/" + bookModel.BookImage;
                            bookModel.BookQuantity = Convert.ToInt32(rd["BookCount"] == DBNull.Value ? default : rd["BookCount"]);


                            bookList.Add(bookModel);
                        }
                    }
                }
                con.Close();
                return bookList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
=======

>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
    }
}
