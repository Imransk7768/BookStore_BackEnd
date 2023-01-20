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
    public class FeedBackRL : IFeedBackRL
    {
        private readonly IConfiguration iConfiguration;
        public FeedBackRL(IConfiguration iconfiguration)
        {
            this.iConfiguration = iconfiguration;
        }
        public string AddFeedback(FeedBackModel feedback, int userId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                try
                {
                    SqlCommand command = new SqlCommand("spAddFeedback", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Rating", feedback.Rating);
                    command.Parameters.AddWithValue("@Comment", feedback.Comment);
                    command.Parameters.AddWithValue("@BookId", feedback.BookId);
                    command.Parameters.AddWithValue("@UserId", userId);

                    con.Open();
                    var result = command.ExecuteNonQuery();
                    con.Close();

                    if (result > 0)
                    {
                        return "Feedback added";
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
        }

        public List<FeedBackModel> GetFeedback(int bookId)
        {
            using (SqlConnection con = new SqlConnection(iConfiguration["ConnectionString:Bookstore"]))
                try
                {
                    List<FeedBackModel> feedbackList = new List<FeedBackModel>();
                    SqlCommand command = new SqlCommand("spGetFeedback", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BookId", bookId);

                    con.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            FeedBackModel fbModel = new FeedBackModel();
                            fbModel.FeedbackId = Convert.ToInt32(dr["FeedbackId"] == DBNull.Value ? default : dr["FeedbackId"]);
                            fbModel.BookId = Convert.ToInt32(dr["BookId"] == DBNull.Value ? default : dr["BookId"]);
                            fbModel.UserId = Convert.ToInt32(dr["UserId"] == DBNull.Value ? default : dr["UserId"]);
                            fbModel.Comment = Convert.ToString(dr["Comment"] == DBNull.Value ? default : dr["Comment"]);
                            fbModel.Rating = Convert.ToDouble(dr["Rating"] == DBNull.Value ? default : dr["Rating"]);
                            fbModel.FullName = Convert.ToString(dr["FullName"] == DBNull.Value ? default : dr["FullName"]);
                            feedbackList.Add(fbModel);
                        }
                        return feedbackList;
                    }
                    else
                    {
                        con.Close();
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
        }
    }
}
