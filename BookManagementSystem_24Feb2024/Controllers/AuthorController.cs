using BMS.DataModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMS.DataLayer.Author;

namespace BookManagementSystem_24Feb2024.Controllers
{
    public class AuthorController : Controller
    {
        //  private readonly AuthorRespository respository;
        private readonly IAuthorRespository respository;
        public AuthorController(IAuthorRespository _respository)
        {
            //respository = new AuthorRespository();
            respository = _respository;
        }
        public IActionResult Index()
        {
            return View(respository.GetAuthors());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (respository.Add(author))
                return RedirectToAction(nameof(Index));

            return View(author);
        }
    }
}
