using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DataLayer.Book
{
  public  class BookRepository : IBookRepository
    {
        private readonly DbContext context;
        public BookRepository()
        {
            context = new DbContext();
        }
        public bool Add(DataModel.Book book)
        {
            try
            {
                context.Books.Add(book);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<DataModel.Book> GetBooks()
        {
            return context.Books.ToList();
        }
    }
}
