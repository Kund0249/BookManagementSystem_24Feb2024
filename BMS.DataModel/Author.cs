using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMS.DataModel
{
    [Table("TAUTHOR")]
   public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }

        //Navigation Properties
        public ICollection<Book> Books { get; set; }
    }
}
