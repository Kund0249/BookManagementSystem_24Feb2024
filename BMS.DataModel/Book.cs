using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMS.DataModel
{
    [Table("TBOOKS")]
   public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("author")]
        public int AuthorId { get; set; }

        //Navigation Properties
        public Author author { get; set; }
    }
}
