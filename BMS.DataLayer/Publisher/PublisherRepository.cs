using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DataLayer.Publisher
{
   public class PublisherRepository : IPublisherRepository
    {
        private readonly DbContext db;
        public PublisherRepository()
        {
            db = new DbContext();
        }
        public List<DataModel.Publisher> GetPublishers()
        {
            return db.Publishers.ToList();
        }

        public bool Add(DataModel.Publisher model)
        {
            try
            {
                db.Publishers.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
