using BAL_CRUD.Services;
using DAL_CRUD.Interface;
using DAL_CRUD.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libraries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CustomersController : ControllerBase
    {
        private readonly BookService _BookService;

        public CustomersController(BookService ProductService)
        {
            _BookService = ProductService;
        }

        [HttpGet]
        public IEnumerable<string> GetCustomers() => new string[] { "Bahaa Ebraheem", "Sary Jouhara" };
      
    }
}