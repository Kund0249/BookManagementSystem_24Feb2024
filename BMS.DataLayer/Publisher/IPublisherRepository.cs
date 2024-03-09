using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.DataModel;

namespace BMS.DataLayer.Publisher
{
   public interface IPublisherRepository
    {
        public List<DataModel.Publisher> GetPublishers();
        public bool Add(DataModel.Publisher publisher);
        public bool Update(DataModel.Publisher publisher);
        public bool Remove(int PublisherId);
        public DataModel.Publisher GetPublisher(int PublisherId);
    }
}
