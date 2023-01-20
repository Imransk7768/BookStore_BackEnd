using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IFeedBackBL
    {
        public string AddFeedback(FeedBackModel feedback, int userId);
        public List<FeedBackModel> GetFeedback(int bookId);
    }
}
