using Microsoft.EntityFrameworkCore;
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
            return context.Books.Include(x => x.author).ToList();
        }

        public void GetBooks2()
        {
            var data = context.Books.Include(x => x.author).Select(x => new
            {
                BookId = x.BookId,
                Text = x.BookName + " : " + x.author.AuthorName
            }).ToList();

            var data2 = (from B in context.Books
                         join T in context.Authors
                         on B.AuthorId equals T.AuthorId
                         select new
                         {
                             BookName = B.BookName,
                             AuthorName = T.AuthorName,
                             CombineValue = B.BookName + " : " + T.AuthorName
                         }
                         ).ToList();
        }
    }
}
