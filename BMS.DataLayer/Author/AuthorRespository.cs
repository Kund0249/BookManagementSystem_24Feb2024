using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DataLayer.Author
{
    public class AuthorRespository : IAuthorRespository
    {
        private readonly DbContext context;
        public AuthorRespository()
        {
            context = new DbContext();
        }

        public bool Add(DataModel.Author author)
        {
            try
            {
                context.Authors.Add(author);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DataModel.Author> GetAuthors()
        {
           return context.Authors.ToList();
        }
    }
}
