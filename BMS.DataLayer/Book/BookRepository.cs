using Microsoft.Data.SqlClient;
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
                //context.Books.Add(book);
                //context.SaveChanges();
                //return true;

                string statuscode = string.Empty;
                string Cs = @"data source=.;database=BookManagement;trusted_connection=true";
                try
                {
                    using (SqlConnection con = new SqlConnection(Cs))
                    {
                        SqlCommand cmd = new SqlCommand("spAddeBook", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ImageUrl", book.ImageUrl);
                        cmd.Parameters.AddWithValue("@bookName", book.BookName);
                        cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                        cmd.Parameters.AddWithValue("@IsActive", book.IsActive);
                        cmd.Parameters.AddWithValue("@AuthorId", book.AuthorId);

                        con.Open();
                        statuscode = (string)cmd.ExecuteScalar();
                        con.Close();
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
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

        public bool Update(DataModel.Book book)
        {
            string statuscode = string.Empty;
            string Cs = @"data source=.;database=BookManagement;trusted_connection=true";
            try
            {
                using(SqlConnection con = new SqlConnection(Cs))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateBook", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@bookId", book.BookId);
                    cmd.Parameters.AddWithValue("@bookName", book.BookName);
                    cmd.Parameters.AddWithValue("@ISBN", book.ISBN);

                    con.Open();
                    statuscode =  (string)cmd.ExecuteScalar();
                    con.Close();
                }

                if (statuscode == "S001")
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
