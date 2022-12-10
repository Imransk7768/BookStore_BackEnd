﻿using BusinessLayer.Interface;
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
        [HttpPost]
        [Route("AddBook")]
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
        [HttpPut]
        [Route("Update")]
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
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteBooks(long bookId)
        {
            try
            {
                var reg = this.ibookBL.DeleteBook(bookId);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Book Deleted Sucessfull", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to delete" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet]
        [Route("GetAllBooks")]
        public IActionResult GetAllbooks()
        {
            try
            {
                var reg = this.ibookBL.GetAllBooks();
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "All Book Details", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to get details" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet]
        [Route("RetriveBook")]
        public IActionResult GetAllbookById(long bookId)
        {
            try
            {
                var reg = this.ibookBL.GetBookById(bookId);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Retrive Book Detail Sucess", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Retrive Failed" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
