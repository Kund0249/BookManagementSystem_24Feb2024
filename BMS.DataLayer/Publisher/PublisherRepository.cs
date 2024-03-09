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
            //using(SqlConnection con = new SqlConnection(CS))
            //{
            //    SqlCommand cmd = new SqlCommand("", con);
            //}
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

        public bool Update(DataModel.Publisher publisher)
        {
            try
            {
                var model = db.Publishers.Find(publisher.PublisherId);
                if(model != null)
                {
                    model.PublisherName = publisher.PublisherName;
                    model.RegNo = publisher.RegNo;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Remove(int PublisherId)
        {
            try
            {
                var publisher = db.Publishers.Find(PublisherId);
                if(publisher != null)
                {
                    db.Publishers.Remove(publisher);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataModel.Publisher GetPublisher(int PublisherId)
        {
            try
            {
                var publisher = db.Publishers.Find(PublisherId);
                
                return publisher;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
