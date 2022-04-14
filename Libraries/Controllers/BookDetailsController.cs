using BAL_CRUD.Services;
using DAL_CRUD.Interface;
using DAL_CRUD.Models;
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
    public class LibraryDetailsController : ControllerBase
    {
        private readonly LibraryService _LibraryService;

        public LibraryDetailsController(LibraryService ProductService)
        {
            _LibraryService = ProductService;
        }

        //Add Library
        [HttpPost("AddLibrary")]
        public async Task<Object> AddLibrary([FromBody] Library Library)
        {
            try
            {
                await _LibraryService.AddLibrary(Library);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete Library
        [HttpDelete("DeleteLibrary")]
        public bool DeleteLibrary(string name, string ownerName)
        {
            try
            {
                _LibraryService.DeleteLibrary(name, ownerName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete Library
        [HttpPut("UpdateLibrary")]
        public bool UpdateLibrary(Library Object)
        {
            try
            {
                _LibraryService.UpdateLibrary(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //GET All Library by Name
        [HttpGet("GetAllLibraryByName")]
        public Object GetAllLibraryByName(string ownerName)
        {
            var data = _LibraryService.GetLibraryByLibraryTitle(ownerName);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Library
        [HttpGet("GetAllLibrarys")]
        public Object GetAllLibrarys()
        {
            var data = _LibraryService.GetAllLibrarys();
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