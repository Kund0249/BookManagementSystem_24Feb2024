﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMS.DataLayer;
using BMS.DataModel;
using BMS.DataLayer.Publisher;

namespace BookManagementSystem_24Feb2024.Controllers
{
    
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository repository;

        public PublisherController(IPublisherRepository publisher)
        {
            //repository = new PublisherRepository();
            repository = publisher;
        }
        public IActionResult Index()
        {
            var data = repository.GetPublishers();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Publisher model)
        {
            repository.Add(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var publisher = repository.GetPublisher(id);

            if(publisher != null)
              return View(publisher);
            else
                return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Publisher model)
        {
            repository.Update(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            repository.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
