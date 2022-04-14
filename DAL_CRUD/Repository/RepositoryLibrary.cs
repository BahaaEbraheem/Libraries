using DAL_CRUD.Data;
using DAL_CRUD.Interface;
using DAL_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL_CRUD.Repository
{
    public class RepositoryLibrary : IRepository<Library>
    {
        ApplicationDbContext _dbContext;
        public RepositoryLibrary(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Library> Create(Library _object)
        {
            var obj = await _dbContext.Libraries.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Library _object)
        {
            _object.IsDeleted = true;
            
            _dbContext.SaveChanges();
        }

        public IEnumerable<Library> GetAll()
        {
            try
            {
                return _dbContext.Libraries.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Library GetById(int Id)
        {
            return _dbContext.Libraries.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
        }

        public void Update(Library _object)
        {
            _dbContext.Libraries.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
