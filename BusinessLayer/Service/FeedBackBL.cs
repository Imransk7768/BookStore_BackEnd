using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class FeedBackBL : IFeedBackBL
    {
        private readonly IFeedBackRL ifeedBackRL;

        public FeedBackBL(IFeedBackRL ifeedBackRL)
        {
            this.ifeedBackRL = ifeedBackRL;
        }
        public string AddFeedback(FeedBackModel feedback, int userId)
        {
            try
            {
                return this.ifeedBackRL.AddFeedback(feedback, userId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<FeedBackModel> GetFeedback(int bookId)
        {
            try
            {
                return this.ifeedBackRL.GetFeedback(bookId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
