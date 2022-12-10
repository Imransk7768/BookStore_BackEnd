using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookBL ibookBL;
        public BookController(IBookBL ibookBL)
        {
            this.ibookBL = ibookBL;

        }
        [HttpPost("Add")]
        public IActionResult AddBook(BookModel bookModel)
        {
            try
            {
                var result = this.ibookBL.AddBook(bookModel);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Book Added Sucessfull", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Book not added" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpPut("Update")]
        public IActionResult UpdateBooks(BookModel bookModel, long bookid)
        {
            try
            {
                var result = this.ibookBL.UpdateBook(bookModel, bookid);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Book Updated Sucessfull", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Book details not updated" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
