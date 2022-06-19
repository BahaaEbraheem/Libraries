using DAL_CRUD.Data;
using DAL_CRUD.Interface;
using DAL_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL_CRUD.Repository
{
    public class RepositoryBook : IRepository<Book>
    {
        ApplicationDbContext _dbContext;
        public RepositoryBook(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Book> Create(Book _object)
        {
            var obj = await _dbContext.Books.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Book _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            try
            {
                return _dbContext.Books.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Book GetById(int Id)
        {
            return _dbContext.Books.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
        }

        public void Update(Book _object)
        {
            _dbContext.Books.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
