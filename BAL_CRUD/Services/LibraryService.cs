using DAL_CRUD.Interface;
using DAL_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_CRUD.Services
{
    public class LibraryService
    {
        private readonly IRepository<Library> _Library;

        public LibraryService(IRepository<Library> Library)
        {
            _Library = Library;
        }
        //Get Library Details By Library Owner
        public IEnumerable<Library> GetLibraryByLibraryTitle(string ownerName)
        {
            return _Library.GetAll().Where(x => x.OwnerName == ownerName).ToList();
        }
        //GET All Librarys Details 
        public IEnumerable<Library> GetAllLibrarys()
        {
            try
            {
                return _Library.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add Library
        public async Task<Library> AddLibrary(Library Library)
        {
            return await _Library.Create(Library);
        }

        //Delete Library 
        public bool DeleteLibrary(string name, string ownerName)
        {

            try
            {
                var DataList = _Library.GetAll().Where(x => x.Name == name && x.OwnerName == ownerName).ToList();
                
                foreach (var item in DataList)
                {
                    _Library.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update Library Details
        public bool UpdateLibrary(Library Library)
        {
            try
            {
                var DataList = _Library.GetAll().Where(x => x.IsDeleted != true).ToList();
                foreach (var item in DataList)
                {
                    _Library.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}