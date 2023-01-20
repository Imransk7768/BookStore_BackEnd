using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        public BookModel AddBook(BookModel bookModel);
        public BookModel UpdateBook(BookModel bookModel, long bookId);
        public bool DeleteBook(long bookId);
        public List<BookModel> GetAllBooks();
        public object GetBookById(long bookId);
    }
}
