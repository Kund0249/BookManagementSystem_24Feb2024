using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagementSystem_24Feb2024.Model;
using BMS.DataLayer.Author;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using BMS.DataLayer.Book;

namespace BookManagementSystem_24Feb2024.Controllers
{
    public class BookController : BaseController
    {
        private readonly IAuthorRespository authorRespository;
        private readonly IWebHostEnvironment _Env;
        private readonly IBookRepository bookRepository;
        public BookController(IAuthorRespository _authorRespository,
            IWebHostEnvironment Env,
            IBookRepository repository)
        {
            authorRespository = _authorRespository;
            _Env = Env;
            bookRepository = repository;
        }


        public IActionResult Index()
        {
            //bookRepository.GetBooks2();
            return View(bookRepository.GetBooks());
        }

        [HttpGet]
        public IActionResult Create()
        {
            BookCreateModel book = new BookCreateModel();

            book.Auhtors = authorRespository.GetAuthors().
                           Select(x => new SelectListItem()
                            {
                                Text = x.AuthorName ,//+ " - " + x.AuthorId.ToString(),
                                Value = x.AuthorId.ToString()
                            }).ToList();

            return View(book);
        }

        [HttpPost]
        public IActionResult Create(BookCreateModel book)
        {
            if (!ModelState.IsValid)
            {
                book.Auhtors = authorRespository.GetAuthors().
                             Select(x => new SelectListItem()
                             {
                                 Text = x.AuthorName,
                                 Value = x.AuthorId.ToString()
                             }).ToList();
            }
            else
            {


                if (book.ImageFile != null)
                {
                    string Extension = System.IO.Path.GetExtension(book.ImageFile.FileName).ToLower();
                    if (Extension == ".jpeg" || Extension == ".png" || Extension == ".jpg")
                    {
                        string folderName = "CoverImages";
                        //_Env.WebRootPath : Return the actual path of wwwroot folder
                        //string serverFolder = _Env.WebRootPath + "/" + folderName + "/myimag.png";
                        string serverFolder = Path.Combine(_Env.WebRootPath, folderName);

                        string fileName = Guid.NewGuid().ToString() + "_" + book.ImageFile.FileName;

                        string filePath = Path.Combine(serverFolder, fileName);

                        book.ImageFile.CopyTo(new FileStream(filePath, FileMode.Create));

                        book.FileName = fileName;

                        //var model = BookCreateModel.Convert(book);
                        //bookRepository.Add(model);

                        bookRepository.Add(BookCreateModel.Convert(book));
                        return RedirectToAction(nameof(Index));
                    }

                }


                book.Auhtors = authorRespository.GetAuthors().
                              Select(x => new SelectListItem()
                              {
                                  Text = x.AuthorName,
                                  Value = x.AuthorId.ToString()
                              }).ToList();
            }
            return View(book);
        }
    }
}
