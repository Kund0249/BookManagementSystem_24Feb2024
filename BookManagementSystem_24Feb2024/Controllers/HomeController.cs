using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystem_24Feb2024.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return "Hello from Home Controller";
            return View();
        }
    }
}
