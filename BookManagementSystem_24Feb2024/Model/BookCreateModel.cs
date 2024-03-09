using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystem_24Feb2024.Model
{
    public class BookCreateModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public bool IsActive { get; set; }
        public int AuhtorId { get; set; }
        public string FileName { get; set; }

        public IFormFile ImageFile { get; set; }
        public List<SelectListItem> Auhtors { get; set; }

        public static BMS.DataModel.Book Convert(BookCreateModel book)
        {
            return new BMS.DataModel.Book()
            {
                BookId = book.BookId,
                BookName = book.BookName,
                AuthorId = book.AuhtorId,
                ImageUrl = book.FileName,
                IsActive = book.IsActive,
                ISBN = book.ISBN
            };
        }
    }
}
