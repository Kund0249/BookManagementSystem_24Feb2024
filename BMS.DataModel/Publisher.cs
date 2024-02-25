using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMS.DataModel
{
    [Table("TPUBLISHER")]
   public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string RegNo { get; set; }
    }
}
