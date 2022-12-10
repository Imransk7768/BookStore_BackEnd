using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class BookBL : IBookBL
    {
        private readonly IBookRL ibookRL;
        public BookBL(IBookRL ibookRL)
        {
            this.ibookRL = ibookRL;
        }
        public BookModel AddBook(BookModel bookModel)
        {
            try
            {
                return this.ibookRL.AddBook(bookModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public BookModel UpdateBook(BookModel bookModel, long bookId)
        {
            try
            {
                return this.ibookRL.UpdateBook(bookModel, bookId);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
