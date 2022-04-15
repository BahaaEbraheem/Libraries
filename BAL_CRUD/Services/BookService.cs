using DAL_CRUD.Interface;
using DAL_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_CRUD.Services
{
    public class BookService
    {
        private readonly IRepository<Book> _book;

        public BookService(IRepository<Book> book)
        {
            _book = book;
        }
        //Get Book Details By Book Title
        public IEnumerable<Book> GetBookByBookTitle(string title)
        {
            return _book.GetAll().Where(x => x.Title == title).ToList();
        }
        //GET All Books Details 
        public IEnumerable<Book> GetAllBooks()
        {
            try
            {
                return _book.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add Book
        public async Task<Book> AddBook(Book book)
        {

            return await _book.Create(book);
        }

        //Delete Book 
        public bool DeleteBook(string title, string authorName)
        {

            try
            {
                var DataList = _book.GetAll().Where(x => x.Title == title).ToList();
                foreach (var item in DataList)
                {
                    _book.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update Book Details
        public bool UpdateBook(Book book)
        {
            try
            {
                var DataList = _book.GetAll().Where(x => x.IsDeleted != true).ToList();
                foreach (var item in DataList)
                {
                    _book.Update(item);
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