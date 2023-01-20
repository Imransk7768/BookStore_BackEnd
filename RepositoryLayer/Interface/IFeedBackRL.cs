using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IFeedBackRL
    {
        public string AddFeedback(FeedBackModel feedback, int userId);
        public List<FeedBackModel> GetFeedback(int bookId);

    }
}
