using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS;

namespace BMS.DataLayer.Book
{
   public interface IBookRepository
    {
        public List<DataModel.Book> GetBooks();
        public bool Add(DataModel.Book book);
        public void GetBooks2();
    }
}
