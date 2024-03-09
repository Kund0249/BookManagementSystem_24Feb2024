using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS;

namespace BMS.DataLayer.Author
{
   public interface IAuthorRespository
    {
        public List<DataModel.Author> GetAuthors();
        public bool Add(DataModel.Author author);
    }
}
