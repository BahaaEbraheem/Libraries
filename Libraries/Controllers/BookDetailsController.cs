using BAL_CRUD.Services;
using DAL_CRUD.Interface;
using DAL_CRUD.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libraries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class BookDetailsController : ControllerBase
    {
        private readonly BookService _BookService;

        public BookDetailsController(BookService ProductService)
        {
            _BookService = ProductService;
        }

        //Add Book
        [HttpPost("AddBook")]
        public async Task<Object> AddBook([FromBody] Book Book)
        {
            try
            {
                await _BookService.AddBook(Book);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete Book
        [HttpDelete("DeleteBook")]
        public bool DeleteBook(string title, string authorName)
        {
            try
            {
                _BookService.DeleteBook(title, authorName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete Book
        [HttpPut("{id}")]
        public bool UpdateBook([FromRoute] int id, [FromBody] Book book)
        {
           
                if (id== book.Id)
                {
                    _BookService.UpdateBook(book);
                return true;

            }
            else
            {
                return false;
            }



        }
        //GET All Book by Name
        [HttpGet("GetAllBookByName")]
        public Object GetAllBookByName(string title)
        {
            var data = _BookService.GetBookByBookTitle(title);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Book
        [HttpGet("GetAllBooks")]
        public Object GetAllBooks()
        {
            var data = _BookService.GetAllBooks();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}